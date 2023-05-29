using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetSortByNameAsync();
        Task<IEnumerable<User>> GetFilteredUsersAsync(int lessThen);
    }
}
