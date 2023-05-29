using AutoMapper;
using EFCollections.BLL.DTO;
using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Profiles
{
    public class CollectionPostDtoProfile : Profile
    {
        public CollectionPostDtoProfile()
        {
            CreateMap<CollectionPostDto, CollectionPost>()
                .ForMember(dest => dest.CollectionId, opt => opt.MapFrom(src => src.CollectionId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
