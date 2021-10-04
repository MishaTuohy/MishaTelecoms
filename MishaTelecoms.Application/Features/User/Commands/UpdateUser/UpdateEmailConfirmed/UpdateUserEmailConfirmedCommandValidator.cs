using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmailConfirmed
{
    public class UpdateUserEmailConfirmedCommandValidator : AbstractValidator<UpdateUserEmailConfirmedCommand>
    {
        public UpdateUserEmailConfirmedCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.EmailConfirmed)
                .NotNull().WithMessage("EmailConfirmed cannot be null");
        }
    }
}
