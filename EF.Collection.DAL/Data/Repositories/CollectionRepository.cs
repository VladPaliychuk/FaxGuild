using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
    {
        public CollectionRepository(CollectionContext collectionContext) : base(collectionContext)
        { 
        }

        public override Task<Collection> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
