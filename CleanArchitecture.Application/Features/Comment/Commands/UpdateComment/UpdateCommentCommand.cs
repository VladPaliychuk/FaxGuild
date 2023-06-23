using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Comment.Commands.UpdateComment
{
    public record class UpdateCommentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Data { get; set; } = null!;
    }
    internal class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.Repository<Domain.Entities.Comment>().GetByIdAsync(request.Id);

            if (comment != null)
            {
                comment.Data = request.Data;
                comment.UpdatedTime = DateTime.Now;

                await _unitOfWork.Repository<Domain.Entities.Comment>().UpdateAsync(comment);
                await _unitOfWork.Save(cancellationToken);

                return true;
            }

            return false;
        }
    }
}
