using AutoMapper;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.IdentityModel.Tokens.Jwt;

namespace EFCollections.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;

        public async Task<JwtResponse> SignInAsync(SignInRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName)
                ?? throw new EntityNotFoundException(
                    $"{nameof(User)} with user name {request.UserName} not found.");

            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new EntityNotFoundException("Incorrect username or password.");
            }

            var jwtToken = tokenService.BuildToken(user);
            return new() { Id = user.Id, Token = tokenService.SerializeToken(jwtToken), UserName = user.UserName/*, RefreshToken = tokenService.GetRefreshToken(user.UserName)*/ };
        }

        public async Task<JwtResponse> SignUpAsync(SignUpRequest request)
        {
            var user = mapper.Map<SignUpRequest, User>(request);
            var signUpResult = await userManager.CreateAsync(user, request.Password);

            if (!signUpResult.Succeeded)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            await unitOfWork.SaveChangesAsync();
            var newUser = await userManager.FindByNameAsync(request.UserName);

            try
            {
                var jwtToken = tokenService.BuildToken(user);
                return new() { UserName = newUser.UserName, Token = tokenService.SerializeToken(jwtToken) /*RefreshToken = tokenService.GetRefreshToken(user.UserName)*/ };
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

        private static string SerializeToken(JwtSecurityToken jwtToken) =>
            new JwtSecurityTokenHandler().WriteToken(jwtToken);

        public IdentityService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ITokenService tokenService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            userManager = this.unitOfWork._userManager;
            this.tokenService = tokenService;
        }
    }
}
