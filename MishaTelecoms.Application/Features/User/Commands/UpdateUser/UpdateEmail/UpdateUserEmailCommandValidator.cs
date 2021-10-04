using FluentValidation;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmail
{
    public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
    {
        public UpdateUserEmailCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(r => r.Email)
                .NotNull().WithMessage("Email cannot be null")
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
