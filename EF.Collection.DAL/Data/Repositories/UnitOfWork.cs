using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CollectionContext databaseContext;

        public ICollectionRepository CollectionRepository { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
             CollectionContext databaseContext,
             ICollectionRepository collection)
        {
            this.databaseContext = databaseContext;

            CollectionRepository = collection;
        }
    }
}
