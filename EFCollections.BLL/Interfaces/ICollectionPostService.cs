using EFCollections.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Interfaces
{
    public interface ICollectionPostService : IService<CollectionPostDto>
    {

        Task DeleteByDoubleIdAsync(int collectionId, int postId);
        Task DeleteByCollectionAsync(int collectionId);
    }
}
