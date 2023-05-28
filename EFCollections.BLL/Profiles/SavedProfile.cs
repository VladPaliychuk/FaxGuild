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
    public class SavedProfile : Profile
    {
        public SavedProfile()
        {
            CreateMap<Saved, SavedDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
