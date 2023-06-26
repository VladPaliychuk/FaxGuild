using EFCollections.BLL.DTO.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Validation
{
    public class UserValidator : AbstractValidator<UserResponse>
    {
        public UserValidator()
        {
        }
    }
}
