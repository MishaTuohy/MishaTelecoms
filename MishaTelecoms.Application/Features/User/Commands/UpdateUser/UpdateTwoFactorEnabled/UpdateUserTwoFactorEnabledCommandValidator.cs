using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateTwoFactorEnabled
{
    public class UpdateUserTwoFactorEnabledCommandValidator : AbstractValidator<UpdateUserTwoFactorEnabledCommand>
    {
        public UpdateUserTwoFactorEnabledCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.TwoFactorEnabled)
                .NotNull().WithMessage("TwoFactorEnabled cannot be null");
        }
    }
}
