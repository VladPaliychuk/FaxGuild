using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(CollectionContext collectionContext) : base(collectionContext) { }

        public override Task<Post> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
