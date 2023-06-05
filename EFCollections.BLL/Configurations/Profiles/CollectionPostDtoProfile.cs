using AutoMapper;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Configurations.Profiles
{
    public class CollectionPostDtoProfile : Profile
    {
        public CollectionPostDtoProfile()
        {
            CreateMap<CollectionPostResponse, CollectionPost>()
                .ForMember(dest => dest.CollectionId, opt => opt.MapFrom(src => src.CollectionId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
