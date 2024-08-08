using BLL_Shop.DTO.User.Update;
using BLL_Shop.Enum;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Shop.Validators.User_Validator
{
    public class UserRoleUpdateValidator : AbstractValidator<UserRoleUpdateDTO>
    {
        public UserRoleUpdateValidator()
        {
            RuleFor(f => f.Role)
                .NotEmpty().WithMessage("Le role est requis")
                .IsEnumName(typeof(UserRoleEnum), caseSensitive: false).WithMessage("Les valeurs attendu pour le champ role sont : 'User' ou 'Admin'");
        }
    }
}
