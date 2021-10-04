using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateUserName
{
    public class UpdateUserUserNameCommandValidator : AbstractValidator<UpdateUserUserNameCommand>
    {
        public UpdateUserUserNameCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.UserName)
                .NotNull().WithMessage("Username cannot be null")
                .MaximumLength(20).WithMessage("Username cannot be longer than 20 characters")
                .MinimumLength(6).WithMessage("Username cannot be shorter than 6 characters");
        }
    }
}