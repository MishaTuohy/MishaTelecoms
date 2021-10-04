using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumber
{
    public class UpdateUserPhoneNumberCommandValidator : AbstractValidator<UpdateUserPhoneNumberCommand>
    {
        public UpdateUserPhoneNumberCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.PhoneNumber)
                .NotNull().WithMessage("PhoneNumber cannot be null")
                .MaximumLength(15).WithMessage("Phone number cannot be longer than 15 digits");
        }
    }
}
