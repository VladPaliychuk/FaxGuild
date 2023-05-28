using EFCollections.DAL.Interfaces.Repositories;
using System.Data;

namespace EFCollections.DAL.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CollectionContext databaseContext;

        public ICollectionRepository _collectionRepository { get; }
        public IUserRepository _userRepository { get; }
        public IStorageRepository _storageRepository { get; }
        public ISavedRepository _savedRepository { get; }
        public IPostRepository _postRepository { get; }
        public ICollectionPostRepository _collectionPostRepository { get; }
        public UnitOfWork(
             CollectionContext databaseContext,
             ICollectionRepository collectionRepository,
             IUserRepository userRepository,
             IStorageRepository storageRepository,
             ISavedRepository savedRepository,
             IPostRepository postRepository,
             ICollectionPostRepository collectionPostRepository
            )
        {
            this.databaseContext = databaseContext;
            this._collectionRepository = collectionRepository;
            this._userRepository = userRepository;
            this._storageRepository = storageRepository;
            this._savedRepository = savedRepository;
            this._postRepository = postRepository;
            this._collectionPostRepository = collectionPostRepository;
        }
        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
