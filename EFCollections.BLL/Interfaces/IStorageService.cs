using EFCollections.BLL.DTO;

namespace EFCollections.BLL.Interfaces
{
    public interface IStorageService : IService<StorageDto>
    {
        Task DeleteByDoubleIdAsync(int userId, int postId);
        Task DeleteByUserAsync(int userId);
    }
}
