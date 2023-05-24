using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        Task AddTagToPost(int postId, string tagName);
        Task<int> GetTagIdByName(string tagName);

        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<int> AddRangeAsync(IEnumerable<T> list);
        Task ReplaceAsync(T t);
        Task<int> AddAsync(T t);
    }
}
