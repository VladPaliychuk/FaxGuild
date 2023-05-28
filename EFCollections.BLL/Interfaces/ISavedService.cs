using EFCollections.BLL.DTO;

namespace EFCollections.BLL.Interfaces
{
    public interface ISavedService : IService<SavedDto>
    {
        Task DeleteByDoubleIdAsync(int userId, int postId);
        Task DeleteByUserAsync(int userId);
    }
}
