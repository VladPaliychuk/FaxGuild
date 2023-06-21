using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface ITokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken> GeTokenByUserName(string username);
        Task DeleteTokenByUserName(string username);
        Task<RefreshToken> GeTokenByToken(string token);
    }
}
