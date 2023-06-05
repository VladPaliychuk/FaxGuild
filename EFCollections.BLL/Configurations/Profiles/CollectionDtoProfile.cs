using AutoMapper;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Configurations.Profiles
{
    public class CollectionDtoProfile : Profile
    {
        public CollectionDtoProfile()
        {
            CreateMap<CollectionResponse, Collection>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));
        }
    }
}
