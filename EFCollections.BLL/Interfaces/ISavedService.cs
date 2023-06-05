using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;

namespace EFCollections.BLL.Interfaces
{
    public interface ISavedService : IService<SavedResponse>
    {
        Task DeleteByDoubleIdAsync(int userId, int postId);
        Task DeleteByUserAsync(int userId);
        Task InsertAsync(SavedRequest request);

        Task UpdateAsync(SavedRequest request);
    }
}
