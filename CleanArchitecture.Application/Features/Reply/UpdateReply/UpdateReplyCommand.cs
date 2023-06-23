using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.Reply.UpdateReply
{
    public record class UpdateReplyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Data { get; set; } = null!;
    }

    internal class UpdateReplyCommandHandler : IRequestHandler<UpdateReplyCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _unitOfWork.Repository<Domain.Entities.Reply>().GetByIdAsync(request.Id);

            if (reply != null)
            {
                reply.Data = request.Data;
                reply.UpdatedTime = DateTime.Now;

                await _unitOfWork.Repository<Domain.Entities.Reply>().UpdateAsync(reply);
                await _unitOfWork.Save(cancellationToken);

                return true;
            }

            return false;
        }
    }
}
