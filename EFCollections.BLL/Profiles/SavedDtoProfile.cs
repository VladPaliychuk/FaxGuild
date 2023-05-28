using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Profiles
{
    public class SavedDtoProfile : Profile
    {
        public SavedDtoProfile()
        {
            CreateMap<SavedDto, Saved>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
