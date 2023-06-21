using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EFCollections.DAL.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CollectionContext databaseContext;

        public ICollectionRepository _collectionRepository { get; }
        public UserManager<User> _userManager { get; }
        public SignInManager<User> _signInManager { get; }
        public IStorageRepository _storageRepository { get; }
        public ISavedRepository _savedRepository { get; }
        public IPostRepository _postRepository { get; }
        public ICollectionPostRepository _collectionPostRepository { get; }
        public ITokenRepository _tokenRepository { get; }
        public UnitOfWork(
             CollectionContext databaseContext,
             ICollectionRepository collectionRepository,
             UserManager<User> userManager,
             SignInManager<User> signInManager,
             ITokenRepository tokenRepository,
             IStorageRepository storageRepository,
             ISavedRepository savedRepository,
             IPostRepository postRepository,
             ICollectionPostRepository collectionPostRepository
            )
        {
            this.databaseContext = databaseContext;
            this._collectionRepository = collectionRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._storageRepository = storageRepository;
            this._savedRepository = savedRepository;
            this._postRepository = postRepository;
            this._tokenRepository = tokenRepository;
            this._collectionPostRepository = collectionPostRepository;
        }
        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
