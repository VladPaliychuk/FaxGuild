using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Reply.DeleteReply
{
    public record class DeleteReplyCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    internal class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _unitOfWork.Repository<Domain.Entities.Reply>().GetByIdAsync(request.Id);
            if (reply != null)
            {
                await _unitOfWork.Repository<Domain.Entities.Reply>().DeleteAsync(reply);
                await _unitOfWork.Save(cancellationToken);
                return 1;
            }
            return 0;
        }
    }
}
