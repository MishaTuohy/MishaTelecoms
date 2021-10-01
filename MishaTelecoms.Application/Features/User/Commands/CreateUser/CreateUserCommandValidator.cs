using FluentValidation;

namespace MishaTelecoms.Application.Features.User.Commands.CreateUser
{
    class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Id cannot be null");
            RuleFor(r => r.UserName).NotNull()
                .WithMessage("Username cannot be null");
            RuleFor(r => r.NormalizedUserName).NotNull()
                .WithMessage("Normalized UserName cannot be null");
            RuleFor(r => r.Email).NotNull()
                .WithMessage("Email cannot be null");
            RuleFor(r => r.NormalizedEmail).NotNull()
                .WithMessage("Normalized Email cannot be null");
            RuleFor(r => r.EmailConfirmed).NotNull()
                .WithMessage("EmailConfirmed cannot be null");
            RuleFor(r => r.PasswordHash).NotNull()
                .WithMessage("PasswordHash cannot be null");
            RuleFor(r => r.PhoneNumber).NotNull()
                .WithMessage("PhoneNumber cannot be null");
            RuleFor(r => r.PhoneNumberConfirmed).NotNull()
                .WithMessage("PhoneNumberConfirmed cannot be null");
            RuleFor(r => r.TwoFactorEnabled).NotNull()
                .WithMessage("TwoFactorEnabled cannot be null");
        }
    }
}
