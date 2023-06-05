using EFCollections.DAL.Entities;
using AutoMapper;
using EFCollections.BLL.DTO.Responses;

namespace EFCollections.BLL.Configurations.Profiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));
        }
    }
}
