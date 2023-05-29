using EFCollections.BLL.DTO;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        Task<IEnumerable<UserDto>> GetSortByNameAsync();
        Task<IEnumerable<UserDto>> GetFilteredUsersAsync(int lessThen);
    }
}
