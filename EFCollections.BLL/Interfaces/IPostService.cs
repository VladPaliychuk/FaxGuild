using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Migrations;

namespace EFCollections.BLL.Interfaces
{
    public interface IPostService : IService<PostResponse>
    {

        Task InsertAsync(PostRequest request);

        Task UpdateAsync(PostRequest request);
    }
}
