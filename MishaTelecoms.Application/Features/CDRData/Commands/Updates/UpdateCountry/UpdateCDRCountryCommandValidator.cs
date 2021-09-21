using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCountry
{
    public class UpdateCDRCountryCommandValidator : AbstractValidator<UpdateCDRCountryCommand>
    {
        public UpdateCDRCountryCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");

            RuleFor(r => r.Country)
                .NotEmpty().WithMessage("Country is required")
                .NotNull().WithMessage("Country cannot be null")
                .MaximumLength(8).WithMessage("Country must not exceed 10 characters.");
        }
    }
}