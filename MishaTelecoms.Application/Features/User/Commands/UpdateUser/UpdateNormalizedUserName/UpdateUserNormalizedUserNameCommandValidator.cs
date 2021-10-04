using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedUserName
{
    public class UpdateUserNormalizedUserNameCommandValidator : AbstractValidator<UpdateUserNormalizedUserNameCommand>
    {
        public UpdateUserNormalizedUserNameCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.NormalizedUserName)
                .NotNull().WithMessage("Normalized UserName cannot be null");
        }
    }
}
