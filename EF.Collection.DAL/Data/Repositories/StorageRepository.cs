using EFCollections.DAL.Entities;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(CollectionContext collectionContext) : base(collectionContext) { }
        public override Task<Storage> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Storage> GetByDoubleIdAsync(int userId, int postId)
        {
            return await table.FindAsync(userId, postId)
            ?? throw new EntityNotFoundException($"{typeof(Storage).Name} with id {userId},{postId} not found.");
        }
        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            var entity = await GetByDoubleIdAsync(userId, postId) ?? throw new EntityNotFoundException($"{typeof(Storage).Name} with id {userId},{postId} not found. Cann't delete.");
            await Task.Run(() => table.Remove(entity));

        }
    }
}
