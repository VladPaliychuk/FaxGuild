using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Comment.Commands.CreateComment
{
    public record class CreateCommentCommand : IRequest<Domain.Entities.Comment>
    {
        public string Data { get; set; } = null!;
        public int PostId { get; set; }
    }
    internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Domain.Entities.Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Domain.Entities.Comment()
            {
                Data = request.Data,
                PostId = request.PostId,
                Likes = 0
            };

            await _unitOfWork.Repository<Domain.Entities.Comment>().AddAsync(comment);
            await _unitOfWork.Save(cancellationToken);
            return comment;
        }
    }
}
