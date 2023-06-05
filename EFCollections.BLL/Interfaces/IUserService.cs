using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Interfaces
{
    public interface IUserService
    {
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task UpdateAsync(UserRequest request);
    }
}
