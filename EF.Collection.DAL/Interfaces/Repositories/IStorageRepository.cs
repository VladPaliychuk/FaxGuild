using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IStorageRepository : IGenericRepository<Storage>
    {
        Task<Storage> GetByDoubleIdAsync(int userId, int postId);
        Task DeleteByDoubleIdAsync(int userId , int postId);
    }
}
