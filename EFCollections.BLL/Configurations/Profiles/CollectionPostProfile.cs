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
    public class CollectionPostProfile : Profile
    {
        public CollectionPostProfile()
        {
            CreateMap<CollectionPost, CollectionPostResponse>()
                .ForMember(dest => dest.CollectionId, opt => opt.MapFrom(src => src.CollectionId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
