﻿using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class SavedRepository : GenericRepository<Saved>, ISavedRepository
    {
        public SavedRepository(CollectionContext collectionContext) : base(collectionContext) { }

        public override Task<Saved> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
