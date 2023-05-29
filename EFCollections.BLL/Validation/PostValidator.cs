using EFCollections.BLL.DTO;
using FluentValidation;

namespace EFCollections.BLL.Validation
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(post => post.Likes)
                .GreaterThanOrEqualTo(0).WithMessage("Likes must be greater than or equal to 0");

            RuleFor(post => post.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(post => post.Picture)
                .NotEmpty().WithMessage("Picture is required");
        }
    }
}
