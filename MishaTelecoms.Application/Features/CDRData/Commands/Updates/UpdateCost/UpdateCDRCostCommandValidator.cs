using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCost
{
    public class UpdateCDRCostCommandValidator : AbstractValidator<UpdateCDRCostCommand>
    {
        public UpdateCDRCostCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");
            RuleFor(r => r.Cost)
                .NotNull().WithMessage("Cost cannot be null");
        }
    }
}
