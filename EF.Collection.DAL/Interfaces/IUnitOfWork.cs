
namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ICollectionRepository CollectionRepository { get; }

        Task SaveChangesAsync();
    }
}
