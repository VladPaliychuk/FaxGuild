using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface ISavedRepository : IGenericRepository<Saved>
    {
        Task<Saved> GetByDoubleIdAsync(int userId, int postId);
        Task DeleteByDoubleIdAsync(int userId, int postId);
    }
}
