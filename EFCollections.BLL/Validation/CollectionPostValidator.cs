using EFCollections.BLL.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Validation
{
    public class CollectionPostValidator : AbstractValidator<CollectionPostDto>
    {
        public CollectionPostValidator()
        {
            RuleFor(cp => cp.CollectionId)
                .GreaterThan(0).WithMessage("CollectionId must be greater than 0");
            RuleFor(cp => cp.PostId)
                .GreaterThan(0).WithMessage("PostId must be greater than 0");
        }
    }
}
