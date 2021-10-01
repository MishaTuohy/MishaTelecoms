using FluentValidation;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByUserName
{
    public class GetUserByUserNameQueryValidator : AbstractValidator<GetUserByUserNameQuery>
    {
        public GetUserByUserNameQueryValidator()
        {
            RuleFor(r => r.UserName).NotNull()
                .WithMessage("UserName cannot be null");
        }
    }
}
