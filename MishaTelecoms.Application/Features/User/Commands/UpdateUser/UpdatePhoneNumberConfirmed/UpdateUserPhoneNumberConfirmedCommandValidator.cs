using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumberConfirmed
{
    public class UpdateUserPhoneNumberConfirmedCommandValidator : AbstractValidator<UpdateUserPhoneNumberConfirmedCommand>
    {
        public UpdateUserPhoneNumberConfirmedCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.PhoneNumberConfirmed)
                .NotNull().WithMessage("PhoneNumberConfirmed cannot be null");
        }
    }
}
