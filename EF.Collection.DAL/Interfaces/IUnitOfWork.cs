
using EFCollections.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ICollectionRepository _collectionRepository { get; }
        ICollectionPostRepository _collectionPostRepository { get; }
        IPostRepository _postRepository { get; }
        ISavedRepository _savedRepository { get; }
        IStorageRepository _storageRepository { get; }
        ITokenRepository _tokenRepository { get; }
        UserManager<User> _userManager { get; }
        SignInManager<User> _signInManager { get; }
        //void Commit();
        //void Dispose();
        Task SaveChangesAsync();
    }
}
