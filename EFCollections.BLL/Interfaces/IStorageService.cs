using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;

namespace EFCollections.BLL.Interfaces
{
    public interface IStorageService : IService<StorageResponse>
    {
        Task DeleteByDoubleIdAsync(int userId, int postId);
        Task DeleteByUserAsync(int userId);
        Task InsertAsync(StorageRequest request);

        Task UpdateAsync(StorageRequest request);
    }
}
