using AutoMapper;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace EFCollections.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IJwtSecurityTokenFactory tokenFactory;

        private readonly UserManager<User> userManager;

        public async Task<JwtResponse> SignInAsync(SignInRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Name)
                ?? throw new EntityNotFoundException(
                    $"{nameof(User)} with user name {request.Name} not found.");

            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new EntityNotFoundException("Incorrect username or password.");
            }

            var jwtToken = tokenFactory.BuildToken(user);
            return new() { Token = SerializeToken(jwtToken), UserId = user.Id.ToString() };
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

            var jwtToken = tokenFactory.BuildToken(user);
            return new() { Token = SerializeToken(jwtToken) };
        }

        private static string SerializeToken(JwtSecurityToken jwtToken) =>
            new JwtSecurityTokenHandler().WriteToken(jwtToken);

        public IdentityService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IJwtSecurityTokenFactory tokenFactory)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.tokenFactory = tokenFactory;
            userManager = this.unitOfWork._userManager;
        }
    }
}
