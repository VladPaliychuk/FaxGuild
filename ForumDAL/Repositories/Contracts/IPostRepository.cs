using ForumDAL.Entities;

namespace ForumDAL.Repositories.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Tag>> GetAllTagsByPostIdAsync(int id);
    }
}
