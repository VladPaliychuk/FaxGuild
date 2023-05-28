using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Profiles;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.BLL.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private IUnitOfWork _unitOfWork;
        public CollectionService(ICollectionRepository collectionRepository, IUnitOfWork unitOfWork)
        {
            _collectionRepository = collectionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionDtoProfile>();
            });

            var mapper = config.CreateMapper();

            await _unitOfWork._collectionRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }   

        public async Task<IEnumerable<CollectionDto>> GetAllAsync()
        {
            var collections = await _collectionRepository.GetAllAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionProfile>();
            });
            var mapper = config.CreateMapper();

            var completeCollectionDto = new List<CollectionDto>();

            foreach (var item in collections)
            {
                CollectionDto collectionDto = mapper.Map<CollectionDto>(item);
                completeCollectionDto.Add(collectionDto);
            }
            return completeCollectionDto;
        }

        public async Task<CollectionDto> GetByIdAsync(int id)
        {
            var collection = await _collectionRepository.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectionProfile>();
            });
            var mapper = config.CreateMapper();

            CollectionDto collectionDto = mapper.Map<CollectionDto>(collection);
            return collectionDto;
        }

        public async Task InsertAsync(CollectionDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CollectionDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Collection collection = mapper.Map<CollectionDto, Collection>(entity);

                await _unitOfWork._collectionRepository.AddAsync(collection);
                await _unitOfWork.SaveChangesAsync();
                
            }
        }

        public async Task UpdateAsync(CollectionDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CollectionDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Collection collection = mapper.Map<CollectionDto, Collection>(entity);

                await _unitOfWork._collectionRepository.UpdateAsync(collection);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
