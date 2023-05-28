
namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ICollectionRepository _collectionRepository { get; }
        ICollectionPostRepository _collectionPostRepository { get; }
        IPostRepository _postRepository { get; }
        ISavedRepository _savedRepository { get; }
        IStorageRepository _storageRepository { get; }
        IUserRepository _userRepository { get; }

        //void Commit();
        //void Dispose();
        Task SaveChangesAsync();
    }
}
