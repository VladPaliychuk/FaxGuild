using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.Comment.Commands.DeleteComment
{
    public record class DeleteCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    internal class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.Repository<Domain.Entities.Comment>().GetByIdAsync(request.Id);
            var replies = await _unitOfWork.Repository<Domain.Entities.Reply>().GetAllAsync();
            foreach (var reply in replies)
            {
                if (reply.CommentId == request.Id)
                {
                    await _unitOfWork.Repository<Domain.Entities.Reply>().DeleteAsync(reply);
                }
            }

            if (comment != null)
            {
                await _unitOfWork.Repository<Domain.Entities.Comment>().DeleteAsync(comment);
                await _unitOfWork.Save(cancellationToken);
                return 1;
            }

            return 0;
        }
    }
}
