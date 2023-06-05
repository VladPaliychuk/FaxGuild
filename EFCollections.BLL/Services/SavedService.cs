using AutoMapper;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.BLL.Services
{
    public class SavedService : ISavedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SavedService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteByDoubleIdAsync(int userId, int postId)
        {
            await _unitOfWork._savedRepository.DeleteByDoubleIdAsync(userId, postId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByUserAsync(int userId)
        {
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
        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork._savedRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<SavedResponse>> GetAllAsync()
        {
            var posts = await _unitOfWork._savedRepository.GetAllAsync();
            return posts?.Select(_mapper.Map<Saved, SavedResponse>);
        }

        public async Task<SavedResponse> GetByIdAsync(int id)
        {
            var post = await _unitOfWork._savedRepository.GetByIdAsync(id);
            return _mapper.Map<Saved, SavedResponse>(post);
        }

        public async Task InsertAsync(SavedRequest request)
        {
            var saved = _mapper.Map<SavedRequest, Saved>(request);
            await _unitOfWork._savedRepository.AddAsync(saved);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(SavedRequest request)
        {
            var post = _mapper.Map<SavedRequest, Saved>(request);
            await _unitOfWork._savedRepository.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
