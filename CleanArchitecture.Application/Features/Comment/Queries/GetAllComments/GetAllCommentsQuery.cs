using AutoMapper;
using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Comment.Queries.GetAllComments
{
    public record class GetAllCommentsQuery : IRequest<List<CommentGetAllDto>>
    {
    }

    internal class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<CommentGetAllDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CommentGetAllDto>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.Repository<Domain.Entities.Comment>().Entities.ToListAsync();

            var dto = _mapper.Map<List<CommentGetAllDto>>(comments);

            return dto;
        }

    }
}
