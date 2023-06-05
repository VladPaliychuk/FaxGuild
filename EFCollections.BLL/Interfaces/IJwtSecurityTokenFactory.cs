using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Interfaces
{
    public interface IJwtSecurityTokenFactory
    {
        JwtSecurityToken BuildToken(User user);
    }
}
