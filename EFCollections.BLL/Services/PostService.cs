using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Profiles;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostDtoProfile>();
            });

            var mapper = config.CreateMapper();

            await _unitOfWork._postRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
            });
            var mapper = config.CreateMapper();

            var completePostDto = new List<PostDto>();

            foreach (var item in posts)
            {
                PostDto postDto = mapper.Map<PostDto>(item);
                completePostDto.Add(postDto);
            }
            return completePostDto;
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
            });
            var mapper = config.CreateMapper();

            PostDto postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task InsertAsync(PostDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostDtoProfile>();
                });

                var mapper = config.CreateMapper();
                //entity.CreateTime = DateTime.Now;
                Post post = mapper.Map<PostDto, Post>(entity);
                await _unitOfWork._postRepository.AddAsync(post);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        public async Task UpdateAsync(PostDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Post post = mapper.Map<PostDto, Post>(entity);

                await _unitOfWork._postRepository.UpdateAsync(post);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
