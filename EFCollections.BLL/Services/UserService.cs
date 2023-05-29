using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Profiles;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System.Globalization;

namespace EFCollections.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserDto>> GetFilteredUsersAsync(int lessThen)
        {
            var filtered = await _unitOfWork._userRepository.GetFilteredUsersAsync(lessThen);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            var mapper = config.CreateMapper();

            var filteredSorted = new List<UserDto>();
            foreach (var item in filtered)
            {
                UserDto userDto = mapper.Map<UserDto>(item);
                filteredSorted.Add(userDto);
            }
            return filteredSorted;
        }
        public async Task<IEnumerable<UserDto>> GetSortByNameAsync()
        {
            var sorted = await _unitOfWork._userRepository.GetSortByNameAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            var mapper = config.CreateMapper();
            var completeSorted = new List<UserDto>();
            foreach (var item in sorted)
            {
                UserDto userDto = mapper.Map<UserDto>(item);
                completeSorted.Add(userDto);
            }
            return completeSorted;
        }
        public async Task DeleteByIdAsync(int id)
        {
            /*var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserDtoProfile>();
            });

            var mapper = config.CreateMapper();
            */
            await _unitOfWork._userRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork._userRepository.GetAllAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            var mapper = config.CreateMapper();

            var completeUserDto = new List<UserDto>();

            foreach (var item in users)
            {
                UserDto userDto = mapper.Map<UserDto>(item);
                completeUserDto.Add(userDto);
            }
            return completeUserDto;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _unitOfWork._userRepository.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            var mapper = config.CreateMapper();

            UserDto userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task InsertAsync(UserDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserDtoProfile>();
                });

                var mapper = config.CreateMapper();
                User user = mapper.Map<UserDto, User>(entity);
                await _unitOfWork._userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        public async Task UpdateAsync(UserDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserDtoProfile>();
                });

                var mapper = config.CreateMapper();

                User user = mapper.Map<UserDto, User>(entity);

                await _unitOfWork._userRepository.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
