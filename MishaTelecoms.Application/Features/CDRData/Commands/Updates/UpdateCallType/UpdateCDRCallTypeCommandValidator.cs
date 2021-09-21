using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallType
{
    public class UpdateCDRCallTypeCommandValidator : AbstractValidator<UpdateCDRCallTypeCommand>
    {
        public UpdateCDRCallTypeCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.CallType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("CallType cannot be null")
                .MaximumLength(5).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
