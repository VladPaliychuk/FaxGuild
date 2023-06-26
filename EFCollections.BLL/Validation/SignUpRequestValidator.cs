using EFCollections.BLL.DTO.Requests;
using FluentValidation;

namespace EFCollections.BLL.Validation
{
    public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpRequestValidator()
        {
            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Password)} can't be empty.")
                .Must(password => password is not null && password.Any(char.IsUpper))
                .WithMessage(request => $"{nameof(request.Password)} must contain an uppercase character.")
                .Must(password => password is not null && password.Any(char.IsLower))
                .WithMessage(request => $"{nameof(request.Password)} must contain a lowercase character.")
                .Must(password => password is not null && password.Any(char.IsDigit))
                .WithMessage(request => $"{nameof(request.Password)} must contain a digit.")
                .MinimumLength(8)
                .WithMessage(request => $"{nameof(request.Password)} must be longer then 8 character");

            RuleFor(request => request.Email)
                .EmailAddress()
                .WithMessage("Wrong email address.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Name)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(request => $"{nameof(request.Name)} should be less than 50 characters.");

            RuleFor(request => request.UserName)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.UserName)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(request => $"{nameof(request.UserName)} should be less than 50 characters.");
        }
    }
}
