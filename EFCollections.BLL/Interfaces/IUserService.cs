using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Interfaces
{
    public interface IUserService
    {
        Task RewokeRefreshToken(string userName, string token);
        Task<UserResponse> GetClientByName(string name);
    }
}
