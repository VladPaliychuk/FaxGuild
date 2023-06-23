using AutoMapper;
using CleanArchitecture.Application.Features.Comment.Queries.GetAllComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Domain.Entities.Comment, CommentGetAllDto>();
        }
    }
}
