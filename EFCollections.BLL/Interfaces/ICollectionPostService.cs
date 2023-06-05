using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Interfaces
{
    public interface ICollectionPostService : IService<CollectionPostResponse>
    {

        Task DeleteByDoubleIdAsync(int collectionId, int postId);
        Task DeleteByCollectionAsync(int collectionId);
        Task InsertAsync(CollectionPostRequest request);
    }
}
