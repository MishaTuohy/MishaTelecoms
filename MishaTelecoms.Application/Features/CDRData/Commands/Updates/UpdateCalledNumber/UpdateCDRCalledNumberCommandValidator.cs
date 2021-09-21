using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCalledNumber
{
    public class UpdateCDRCalledNumberCommandValidator : AbstractValidator<UpdateCDRCalledNumberCommand>
    {
        public UpdateCDRCalledNumberCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.CalledNumber)
                .NotEmpty().WithMessage("CalledNumber is required")
                .NotNull().WithMessage("CalledNumber cannot be null")
                .MaximumLength(10).WithMessage("CalledNumber must not exceed 10 characters.");
        }
    }
}
