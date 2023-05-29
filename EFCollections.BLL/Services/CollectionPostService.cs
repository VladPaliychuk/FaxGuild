using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Profiles;
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
        public CollectionPostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteByDoubleIdAsync(int collectionId, int postId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionPostDtoProfile>();
            });

            var mapper = config.CreateMapper();

            await _unitOfWork._collectionPostRepository.DeleteByDoubleIdAsync(collectionId, postId);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByCollectionAsync(int collectionId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionPostDtoProfile>();
            });

            var mapper = config.CreateMapper();

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
        public async Task<IEnumerable<CollectionPostDto>> GetAllAsync()
        {
            var collectionPosts = await _unitOfWork._collectionPostRepository.GetAllAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionPostProfile>();
            });
            var mapper = config.CreateMapper();

            var completeCollectionPostDto = new List<CollectionPostDto>();

            foreach (var item in collectionPosts)
            {
                CollectionPostDto collectionPostDto = mapper.Map<CollectionPostDto>(item);
                completeCollectionPostDto.Add(collectionPostDto);
            }
            return completeCollectionPostDto;
        }

        public async Task<CollectionPostDto> GetByIdAsync(int id)
        {
            var collectionPost = await _unitOfWork._collectionPostRepository.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionPostProfile>();
            });
            var mapper = config.CreateMapper();

            CollectionPostDto collectionPostDto = mapper.Map<CollectionPostDto>(collectionPost);
            return collectionPostDto;
        }

        public async Task InsertAsync(CollectionPostDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CollectionPostDtoProfile>();
                });

                var mapper = config.CreateMapper();

                CollectionPost collectionPost = mapper.Map<CollectionPostDto, CollectionPost>(entity);

                await _unitOfWork._collectionPostRepository.AddAsync(collectionPost);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        public async Task UpdateAsync(CollectionPostDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CollectionDtoProfile>();
                });

                var mapper = config.CreateMapper();

                CollectionPost collectionPost = mapper.Map<CollectionPostDto, CollectionPost>(entity);

                await _unitOfWork._collectionPostRepository.UpdateAsync(collectionPost);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
