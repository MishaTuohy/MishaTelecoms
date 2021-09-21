using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateDuration
{
    public class UpdateCDRDurationCommandValidator : AbstractValidator<UpdateCDRDurationCommand>
    {
        public UpdateCDRDurationCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.Duration)
                .NotNull().WithMessage("Duration cannot be null");
        }
    }
}