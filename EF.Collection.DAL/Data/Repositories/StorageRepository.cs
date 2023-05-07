using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(CollectionContext collectionContext) : base(collectionContext)
        {
        }

        public override Task<Storage> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
