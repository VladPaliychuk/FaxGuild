using AutoMapper;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Configurations.Profiles
{
    public class SignUpProfile : Profile
    {
        public SignUpProfile()
        {
            CreateMap<SignUpRequest, User>();
        }
    }
}
