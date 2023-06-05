using AutoMapper;
using EFCollections.BLL.Configurations.Profiles;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Services
{
    public class CollectionPostService : ICollectionPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CollectionPostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            await _unitOfWork._collectionPostRepository.DeleteByDoubleIdAsync(userId, postId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByCollectionAsync(int collectionId)
        {
            var collectionPosts = await _unitOfWork._collectionPostRepository.GetAllAsync();

            foreach (var collectionPost in collectionPosts)
            {
                if (collectionPost.CollectionId == collectionId)
                {
                    await _unitOfWork._collectionPostRepository.DeleteByDoubleIdAsync(collectionId, collectionPost.PostId);
                }
            }
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork._collectionPostRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CollectionPostResponse>> GetAllAsync()
        {
            var posts = await _unitOfWork._collectionPostRepository.GetAllAsync();
            return posts?.Select(_mapper.Map<CollectionPost, CollectionPostResponse>);
        }

        public async Task<CollectionPostResponse> GetByIdAsync(int id)
        {
            var post = await _unitOfWork._collectionPostRepository.GetByIdAsync(id);
            return _mapper.Map<CollectionPost, CollectionPostResponse>(post);
        }

        public async Task InsertAsync(CollectionPostRequest request)
        {
            var collectionPost = _mapper.Map<CollectionPostRequest, CollectionPost>(request);
            await _unitOfWork._collectionPostRepository.AddAsync(collectionPost);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
