using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface ICollectionPostRepository : IGenericRepository<CollectionPost>
    {
        Task<CollectionPost> GetByDoubleIdAsync(int collectionId, int postId);
        Task DeleteByDoubleIdAsync(int collectionId, int postId);
    }
}
