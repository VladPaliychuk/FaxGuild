using AutoMapper;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Configurations.Profiles
{
    public class PostDtoProfile : Profile
    {
        public PostDtoProfile()
        {
            CreateMap<PostResponse, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
