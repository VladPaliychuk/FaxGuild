using EFCollections.DAL.Entities;
using AutoMapper;
using EFCollections.BLL.DTO;

namespace EFCollections.BLL.Profiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));
        }
    }
}
