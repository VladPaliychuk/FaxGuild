using Forum.BLL.DTOs;

namespace Forum.BLL.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> GetPostById(int id);
        Task<IEnumerable<PostDto>> GetAllPosts();
        Task<int?> GetAverageLikes();
    }
}
