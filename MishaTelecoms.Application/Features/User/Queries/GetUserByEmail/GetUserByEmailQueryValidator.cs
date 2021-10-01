using FluentValidation;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(r => r.Email).NotNull()
                .WithMessage("Email cannot be null");
        }
    }
}
