using EFCollections.BLL.DTO.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Validation
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
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

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Name)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(request => $"{nameof(request.Name)} should be less than 50 characters.");
        }
    }
}
