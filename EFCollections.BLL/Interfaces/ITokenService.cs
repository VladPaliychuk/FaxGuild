using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Interfaces
{
    public interface ITokenService
    {
        string SerializeToken(JwtSecurityToken jwtToken);
        string GetRefreshToken(string username);
        bool IsValid(JwtResponse response, out string username);
        string GetAccessTokenByRefreshToken(string refreshToken);
        JwtSecurityToken BuildToken(User user);
        void DeleteRefreshToken(string username);
    }
}
