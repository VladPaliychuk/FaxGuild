using AutoMapper;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Configurations.Profiles
{
    public class SavedDtoProfile : Profile
    {
        public SavedDtoProfile()
        {
            CreateMap<SavedResponse, Saved>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
