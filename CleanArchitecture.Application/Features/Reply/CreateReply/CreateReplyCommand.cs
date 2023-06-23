using MediatR;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Interfaces.Repositories;

namespace CleanArchitecture.Application.Features.Reply.CreateComment
{
    public record class CreateReplyCommand : IRequest<Domain.Entities.Reply>
    {
        public string Data { get; set; } = null!;
        public int CommentId { get; set; }
    }
    internal class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, Domain.Entities.Reply>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Domain.Entities.Reply> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = new Domain.Entities.Reply()
            {
                Data = request.Data,
                CommentId = request.CommentId,
                CreatedTime = DateTime.Now
            };
            await _unitOfWork.Repository<Domain.Entities.Reply>().AddAsync(reply);
            await _unitOfWork.Save(cancellationToken);
            return reply;
        }
    }
}
