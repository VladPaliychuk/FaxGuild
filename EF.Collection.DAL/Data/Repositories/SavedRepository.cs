using EFCollections.DAL.Entities;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class SavedRepository : GenericRepository<Saved>, ISavedRepository
    {
        public SavedRepository(CollectionContext collectionContext) : base(collectionContext) { }

        public override Task<Saved> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Saved> GetByDoubleIdAsync(int userId, int postId)
        {
            return await table.FindAsync(userId, postId)
            ?? throw new EntityNotFoundException($"{typeof(Saved).Name} with id {userId},{postId} not found.");
        }
        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            var entity = await GetByDoubleIdAsync(userId, postId) ?? throw new EntityNotFoundException($"{typeof(Saved).Name} with id {userId},{postId} not found. Cann't delete.");
            await Task.Run(() => table.Remove(entity));

        }
    }
}
