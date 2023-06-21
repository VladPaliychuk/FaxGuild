using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class TokenRepository : GenericRepository<RefreshToken>, ITokenRepository
    {

        public TokenRepository(CollectionContext databaseContext) : base(databaseContext) { }

        public async Task<RefreshToken> GeTokenByUserName(string username) => 
            await table.Where(p => p.UserName == username).FirstOrDefaultAsync();

        public async Task DeleteTokenByUserName(string username)
        {
            var entity = await table.Where(p => p.UserName == username).FirstOrDefaultAsync();
            await Task.Run(() => table.Remove(entity));
        }

        public async Task<RefreshToken> GeTokenByToken(string token) =>
            await table.Where(p => p.UserSecret == token).FirstOrDefaultAsync();

        public override Task<RefreshToken> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
