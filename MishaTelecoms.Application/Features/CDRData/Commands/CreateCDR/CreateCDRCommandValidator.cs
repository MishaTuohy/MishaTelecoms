using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CreateCDR
{
    public class CreateCDRCommandValidator : AbstractValidator<CreateCDRCommand>
    {
        public CreateCDRCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.CalledNumber)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull()
             .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");

            //to do, finish validation rules

        }
    }
}
