using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Profiles;
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
        private IUnitOfWork _unitOfWork;
        public StorageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StorageDtoProfile>();
            });

            var mapper = config.CreateMapper();

            await _unitOfWork._storageRepository.DeleteByDoubleIdAsync(userId, postId);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByUserAsync(int userId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StorageDtoProfile>();
            });

            var mapper = config.CreateMapper();

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
        public async Task<IEnumerable<StorageDto>> GetAllAsync()
        {
            var storages = await _unitOfWork._storageRepository.GetAllAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StorageProfile>();
            });
            var mapper = config.CreateMapper();

            var completeStorageDto = new List<StorageDto>();

            foreach (var item in storages)
            {
                StorageDto storageDto = mapper.Map<StorageDto>(item);
                completeStorageDto.Add(storageDto);
            }
            return completeStorageDto;
        }

        public async Task<StorageDto> GetByIdAsync(int id)
        {
            var storage = await _unitOfWork._storageRepository.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StorageProfile>();
            });
            var mapper = config.CreateMapper();

            StorageDto storageDto = mapper.Map<StorageDto>(storage);
            return storageDto;
        }

        public async Task InsertAsync(StorageDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<StorageDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Storage storage = mapper.Map<StorageDto, Storage>(entity);

                await _unitOfWork._storageRepository.AddAsync(storage);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        public async Task UpdateAsync(StorageDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CollectionDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Storage storage = mapper.Map<StorageDto, Storage>(entity);

                await _unitOfWork._storageRepository.UpdateAsync(storage);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
