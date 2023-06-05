using AutoMapper;
using EFCollections.BLL.Configurations.Profiles;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Data.Repositories;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Services
{
    public class StorageService : IStorageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StorageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            await _unitOfWork._storageRepository.DeleteByDoubleIdAsync(userId, postId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByUserAsync(int userId)
        {
            var storages = await _unitOfWork._storageRepository.GetAllAsync();

            foreach (var storage in storages)
            {
                if (storage.UserId == userId)
                {
                    await _unitOfWork._storageRepository.DeleteByDoubleIdAsync(userId, storage.PostId);
                }
            }
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork._storageRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<StorageResponse>> GetAllAsync()
        {
            var posts = await _unitOfWork._storageRepository.GetAllAsync();
            return posts?.Select(_mapper.Map<Storage, StorageResponse>);
        }

        public async Task<StorageResponse> GetByIdAsync(int id)
        {
            var post = await _unitOfWork._storageRepository.GetByIdAsync(id);
            return _mapper.Map<Storage, StorageResponse>(post);
        }

        public async Task InsertAsync(StorageRequest request)
        {
            var storage = _mapper.Map<StorageRequest, Storage>(request);
            await _unitOfWork._storageRepository.AddAsync(storage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(StorageRequest request)
        {
            var post = _mapper.Map<StorageRequest, Storage>(request);
            await _unitOfWork._storageRepository.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
