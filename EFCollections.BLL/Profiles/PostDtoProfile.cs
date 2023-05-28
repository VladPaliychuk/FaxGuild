using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Profiles
{
    public class PostDtoProfile : Profile
    {
        public PostDtoProfile()
        {
            CreateMap<PostDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
