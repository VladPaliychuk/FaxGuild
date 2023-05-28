using EFCollections.DAL.Entities;
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
    }
}
