using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EFCollections.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IJwtSecurityTokenFactory jwtSecurityTokenFactory;

        public TokenService(IUnitOfWork unitOfWork, IConfiguration configuration, IJwtSecurityTokenFactory jwtSecurityTokenFactory)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.jwtSecurityTokenFactory = jwtSecurityTokenFactory;
        }
        public string SerializeToken(JwtSecurityToken jwtToken) =>
            new JwtSecurityTokenHandler().WriteToken(jwtToken);

        public JwtSecurityToken BuildToken(User user) => jwtSecurityTokenFactory.BuildToken(user);

        public string GetAccessTokenByRefreshToken(string refreshToken)
        {

            try
            {
                var token = unitOfWork._tokenRepository.GeTokenByToken(refreshToken);

                if (token.Result == null)
                {

                    throw new UnauthorizedAccessException("token is not to be)");
                }
                if (token.Result.ExpirationDate <= DateTime.Now)
                {
                    unitOfWork._tokenRepository.DeleteTokenByUserName(token.Result.UserName);
                    unitOfWork.SaveChangesAsync();
                    throw new UnauthorizedAccessException("Refresh Token is expired,it will be deleted");
                }

                var client = unitOfWork._userManager.FindByNameAsync(token.Result.UserName);

                if (client.Result == null)
                {
                    throw new NullReferenceException($"{nameof(client)} is not excist");
                }

                var jwtSecutity = BuildToken(client.Result);
                return SerializeToken(jwtSecutity);
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        public void DeleteRefreshToken(string clientName)
        {
            try
            {
                unitOfWork._tokenRepository.DeleteTokenByUserName(clientName);
                unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }

        }
        public string GetRefreshToken(string username)
        {
            try
            {
                var ifrexisttoken = unitOfWork._tokenRepository.GeTokenByUserName(username);
                if (ifrexisttoken.Result == null)
                {
                    var newguid = Guid.NewGuid();
                    unitOfWork._tokenRepository.AddAsync(new RefreshToken { UserName = username, UserSecret = newguid.ToString(), ExpirationDate = DateTime.Now.AddDays(1) });
                    unitOfWork.SaveChangesAsync();

                    return newguid.ToString();
                }

                if (ifrexisttoken.Result.ExpirationDate > DateTime.Now)
                {
                    unitOfWork._tokenRepository.DeleteTokenByUserName(ifrexisttoken.Result.UserName);
                    unitOfWork.SaveChangesAsync().Wait();

                    throw new Exception("Token is Expirationed it will be deleted you must login again");
                }
                return ifrexisttoken.Result.UserSecret;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public bool IsValid(JwtResponse response, out string username)
        {
            username = string.Empty;
            ClaimsPrincipal principal = GetPrincipalFromExpiredToken(response.Token);
            if (principal is null)
            {
                throw new UnauthorizedAccessException("No principal");
            }

            username = principal.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrEmpty(username))
            {
                throw new UnauthorizedAccessException("No user name");
            }

            /*if (!Guid.TryParse(response.RefreshToken, out Guid givenRefreshToken))
            {
                throw new UnauthorizedAccessException("Refresh token malformed");
            }*/
            var curenttoken = unitOfWork._tokenRepository.GeTokenByUserName(response.UserName);
            Guid curentRefreshToken = Guid.Parse(curenttoken.Result.UserSecret);

            if (curenttoken.Result.ExpirationDate >= DateTime.Now)
            {
                unitOfWork._tokenRepository.DeleteTokenByUserName(username);
                throw new UnauthorizedAccessException("Refresh Token is expired,it will be deleted");

            }
/*
            if (curentRefreshToken == null)
            {
                throw new UnauthorizedAccessException("No valid refresh token in system");

            }*/
            /*if (curentRefreshToken != givenRefreshToken)
            {
                throw new UnauthorizedAccessException("invalid refresh token");
            }*/

            return true;

        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                                 Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"])),



            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            ClaimsPrincipal claimsPrincipal = handler.ValidateToken(
                token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCulture))
            {
                throw new SecurityTokenException("invalid token");
            }


            return claimsPrincipal;

        }
    }
}
