using EFCollections.BLL.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(15).WithMessage("Name cannot exceed 15 characters");
        }
    }
}
