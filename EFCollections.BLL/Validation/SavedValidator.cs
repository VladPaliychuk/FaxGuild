using EFCollections.BLL.DTO.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Validation
{
    public class SavedValidator : AbstractValidator<SavedResponse>
    {
        public SavedValidator()
        {
            RuleFor(st => st.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
            RuleFor(st => st.PostId)
                .GreaterThan(0).WithMessage("PostId must be greater than 0");
        }
    }
}
