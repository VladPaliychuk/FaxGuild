using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;

namespace EFCollections.BLL.Interfaces
{
    public interface ICollectionService : IService<CollectionResponse>
    {
        Task InsertAsync(CollectionRequest request);

        Task UpdateAsync(CollectionRequest request);
    }
}
