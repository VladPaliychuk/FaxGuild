using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Profiles
{
    public class CollectionDtoProfile : Profile
    {
        public CollectionDtoProfile()
        {
            CreateMap<CollectionDto, Collection>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));
        }
    }
}
