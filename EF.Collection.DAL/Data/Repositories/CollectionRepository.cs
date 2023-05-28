using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
    {
        public CollectionRepository(CollectionContext collectionContext) : base(collectionContext) { }
        DbSet<Collection> DbSet { get; set; }
        public override Task<Collection> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
        /*public override async Task AddAsync(Collection collection)
        {
            await DbSet.AddAsync(collection);
        }*/
    }
}
