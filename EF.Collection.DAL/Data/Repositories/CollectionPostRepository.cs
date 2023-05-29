using EFCollections.DAL.Entities;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class CollectionPostRepository : GenericRepository<CollectionPost>, ICollectionPostRepository
    {
        public CollectionPostRepository(CollectionContext collectionContext) : base(collectionContext) { }

        public override Task<CollectionPost> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<CollectionPost> GetByDoubleIdAsync(int collectionId, int postId)
        {
            return await table.FindAsync(collectionId, postId)
            ?? throw new EntityNotFoundException($"{typeof(CollectionPost).Name} with id {collectionId},{postId} not found.");
        }
        public async Task DeleteByDoubleIdAsync(int collectionId, int postId)
        {
            var entity = await GetByDoubleIdAsync(collectionId, postId) ?? throw new EntityNotFoundException($"{typeof(Saved).Name} with id {collectionId},{postId} not found. Cann't delete.");
            await Task.Run(() => table.Remove(entity));
        }
    }
}
