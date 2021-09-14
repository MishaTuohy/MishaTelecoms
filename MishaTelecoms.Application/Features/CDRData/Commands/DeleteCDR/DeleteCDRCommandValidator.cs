using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.DeleteCDR
{
    public class DeleteCDRCommandValidator : AbstractValidator<DeleteCDRCommand>
    {
        public DeleteCDRCommandValidator()
        {
            RuleFor(r=> r.Id)
                .NotNull().WithMessage("Guid cannot be null");
        }
    }
}
