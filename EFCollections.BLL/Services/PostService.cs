using AutoMapper;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task UpdateLikesAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            post.Likes += 1;
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork._postRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostResponse>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts?.Select(_mapper.Map<Post, PostResponse>);
        }

        public async Task<PostResponse> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id); 
            return _mapper.Map<Post, PostResponse>(post);
        }

        public async Task InsertAsync(PostRequest request)
        {
            request.CreateTime = DateTime.Now;
            var post = _mapper.Map<PostRequest, Post>(request);
            await _unitOfWork._postRepository.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostRequest request)
        {
            var post = _mapper.Map<PostRequest, Post>(request);
            await _unitOfWork._postRepository.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
