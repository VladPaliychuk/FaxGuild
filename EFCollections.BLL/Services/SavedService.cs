using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Profiles;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.BLL.Services
{
    public class SavedService : ISavedService
    {
        private IUnitOfWork _unitOfWork;
        public SavedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SavedDtoProfile>();
            });

            var mapper = config.CreateMapper();

            await _unitOfWork._savedRepository.DeleteByDoubleIdAsync(userId, postId);
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
                cfg.AddProfile<SavedDtoProfile>();
            });

            var mapper = config.CreateMapper();

            var saveds = await _unitOfWork._savedRepository.GetAllAsync();

            foreach (var saved in saveds)
            {
                if (saved.UserId == userId)
                {
                    await _unitOfWork._savedRepository.DeleteByDoubleIdAsync(userId, saved.PostId);
                }
            }
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<SavedDto>> GetAllAsync()
        {
            var saveds = await _unitOfWork._savedRepository.GetAllAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SavedProfile>();
            });
            var mapper = config.CreateMapper();

            var completeSavedDto = new List<SavedDto>();

            foreach (var item in saveds)
            {
                SavedDto savedDto = mapper.Map<SavedDto>(item);
                completeSavedDto.Add(savedDto);
            }
            return completeSavedDto;
        }

        public async Task<SavedDto> GetByIdAsync(int id)
        {
            var saved = await _unitOfWork._savedRepository.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SavedProfile>();
            });
            var mapper = config.CreateMapper();

            SavedDto savedDto = mapper.Map<SavedDto>(saved);
            return savedDto;
        }

        public async Task InsertAsync(SavedDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<SavedDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Saved saved = mapper.Map<SavedDto, Saved>(entity);

                await _unitOfWork._savedRepository.AddAsync(saved);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        public async Task UpdateAsync(SavedDto entity)
        {
            if (entity is not null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CollectionDtoProfile>();
                });

                var mapper = config.CreateMapper();

                Saved saved = mapper.Map<SavedDto, Saved>(entity);

                await _unitOfWork._savedRepository.UpdateAsync(saved);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
