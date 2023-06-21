using AutoMapper;
using Azure.Core;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EFCollections.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            userManager = this._unitOfWork._userManager;
            this.mapper = mapper;
        }
        public async Task DeleteByIdAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return users?.Select(mapper.Map<User, UserResponse>);
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            return mapper.Map<User, UserResponse>(user);
        }

        /*public async Task InsertAsync(UserResponse entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserDtoProfile>();
                });

                var mapper = config.CreateMapper();
                User user = mapper.Map<UserResponse, User>(entity);
                await userManager.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

            }
        }*/

        public async Task UpdateAsync(UserRequest request)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());

            user.Name = request.Name;
            user.Email = request.Email;

            await userManager.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
