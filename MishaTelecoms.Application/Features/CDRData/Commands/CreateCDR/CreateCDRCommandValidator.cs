using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CreateCDR
{
    public class CreateCDRCommandValidator : AbstractValidator<CreateCDRCommand>
    {
        public CreateCDRCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.CallingNumber)
             .NotEmpty().WithMessage("CallingNumber is required")
             .NotNull().WithMessage("CallingNumber cannot be null")
             .MaximumLength(10).WithMessage("CallingNumber must not exceed 10 characters.");

            RuleFor(r => r.CalledNumber)
                .NotEmpty().WithMessage("CalledNumber is required")
                .NotNull().WithMessage("CalledNumber cannot be null")
                .MaximumLength(10).WithMessage("CalledNumber must not exceed 10 characters.");

            RuleFor(r => r.Country)
                .NotEmpty().WithMessage("Country is required")
                .NotNull().WithMessage("Country cannot be null")
                .MaximumLength(8).WithMessage("Country must not exceed 10 characters.");

            RuleFor(r => r.CallType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("CallType cannot be null")
                .MaximumLength(5).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(r => r.Duration)
                .NotNull().WithMessage("Duration cannot be null");

            RuleFor(r => r.DateCreated)
                .NotEmpty().WithMessage("DateCreated is required")
                .NotNull().WithMessage("DateCreated cannot be null")
                .MaximumLength(8).WithMessage("DateCreated must not exceed 10 characters.");

            RuleFor(r => r.Cost)
                .NotNull().WithMessage("Cost cannot be null");
        }
    }
}
