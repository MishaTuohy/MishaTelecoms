using FluentValidation;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Delete
{
    public class DeleteCDRCommandValidator : AbstractValidator<DeleteCDRCommand>
    {
        public DeleteCDRCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Guid cannot be null");
        }
    }
}
