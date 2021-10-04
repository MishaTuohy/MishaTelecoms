using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePassword
{
    public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
    {
        public UpdateUserPasswordCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");
            RuleFor(r => r.PasswordHash)
                .NotNull().WithMessage("PasswordHash cannot be null");
        }
    }
}
