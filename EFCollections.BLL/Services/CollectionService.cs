using AutoMapper;
using EFCollections.BLL.Configurations.Profiles;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.BLL.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CollectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork._collectionRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CollectionResponse>> GetAllAsync()
        {
            var posts = await _unitOfWork._collectionRepository.GetAllAsync();
            return posts?.Select(_mapper.Map<Collection, CollectionResponse>);
        }

        public async Task<CollectionResponse> GetByIdAsync(int id)
        {
            var post = await _unitOfWork._collectionRepository.GetByIdAsync(id);
            return _mapper.Map<Collection, CollectionResponse>(post);
        }

        public async Task InsertAsync(CollectionRequest request)
        {
            var collection = _mapper.Map<CollectionRequest, Collection>(request);
            await _unitOfWork._collectionRepository.AddAsync(collection);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(CollectionRequest request)
        {
            var post = _mapper.Map<CollectionRequest, Collection>(request);
            await _unitOfWork._collectionRepository.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
