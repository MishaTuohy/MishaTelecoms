using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallingNumber
{
    public class UpdateCDRCallingNumberCommandValidator : AbstractValidator<UpdateCDRCallingNumberCommand>
    {
        public UpdateCDRCallingNumberCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.CallingNumber)
             .NotEmpty().WithMessage("CallingNumber is required")
             .NotNull().WithMessage("CallingNumber cannot be null")
             .MaximumLength(10).WithMessage("CallingNumber must not exceed 10 characters.");
        }
    }
}
