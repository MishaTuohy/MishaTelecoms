using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateAll
{
    public class UpdateCDRAllCommandValidator : AbstractValidator<UpdateCDRAllCommand>
    {
        public UpdateCDRAllCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.CallingNumber)
             .MaximumLength(10).WithMessage("CallingNumber must not exceed 10 characters.");

            RuleFor(r => r.CalledNumber)
                .MaximumLength(10).WithMessage("CalledNumber must not exceed 10 characters.");

            RuleFor(r => r.Country)
                .MaximumLength(8).WithMessage("Country must not exceed 10 characters.");

            RuleFor(r => r.CallType)
                .MaximumLength(5).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(r => r.DateCreated)
                .MaximumLength(8).WithMessage("DateCreated must not exceed 10 characters.");

            RuleFor(r => r.Cost);
        }
    }
}