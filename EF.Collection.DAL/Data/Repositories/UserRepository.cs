using EFCollections.DAL.Entities;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> table;
        public UserRepository(CollectionContext collectionContext) : base(collectionContext)
        {
            table = databaseContext.Set<User>();
        }
        
        public override Task<User> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetSortByNameAsync()
        {
            //var users = await table.OrderBy(x => x.Name).ToListAsync();
            return await table.OrderBy(x => x.Name).ToListAsync()
            ?? throw new EntityNotFoundException($"{typeof(User)} is null.");
        }

        public async Task<IEnumerable<User>> GetFilteredUsersAsync(int lessThen)
        {
            return await table.Where(x => x.Id < lessThen).ToListAsync()
                ?? throw new EntityNotFoundException($"{typeof(User)} hasn't filtered columns.");
        }
    }
}
