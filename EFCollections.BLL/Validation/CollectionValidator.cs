﻿using EFCollections.BLL.DTO.Responses;
using FluentValidation;

namespace EFCollections.BLL.Validation
{
    public class CollectionValidator : AbstractValidator<CollectionResponse>
    {
        public CollectionValidator()
        {
            RuleFor(collection => collection.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(collection => collection.AuthorId)
                .GreaterThan(0).WithMessage("AuthorId must be greater than 0");
        }
    }
}