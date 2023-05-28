using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CollectionContext collectionContext) : base(collectionContext) { }

        public override Task<User> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
