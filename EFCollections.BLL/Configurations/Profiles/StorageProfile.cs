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
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<Storage, StorageResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
