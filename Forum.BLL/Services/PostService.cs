using AutoMapper;
using Forum.BLL.DTOs;
using Forum.BLL.Interfaces;
using Forum.BLL.Profiles;
using ForumDAL.Repositories.Contracts;
using System.Data;

namespace Forum.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDto>>GetAllPosts()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
            });
            var mapper = config.CreateMapper();

            var completePostsDto = new List<PostDto>();
            var posts = await _postRepository.GetAllAsync();
            foreach(var post in posts)
            {
                PostDto postDto = mapper.Map<PostDto>(post);
                completePostsDto.Add(postDto);
            }
            return completePostsDto;
        }

        public async Task<PostDto> GetPostById(int postId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
            });
            var mapper = config.CreateMapper();

            var post = await _postRepository.GetAsync(postId);
            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }
        public async Task<int?> GetAverageLikes()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
            });
            var mapper = config.CreateMapper();
            var likes = new List<int?>();
            var posts = await _postRepository.GetAllAsync();
            foreach (var post in posts)
            {
                if(post.Likes is not null)
                {
                    PostDto postDto = mapper.Map<PostDto>(post);
                    likes.Add(postDto.Likes);
                }
            }
            int? allLikes = 0;
            foreach(var like in likes)
            {
                allLikes += like;
            }
            int? avg = allLikes / likes.Count;
            return avg;
        }
    }
}
