using FluentValidation;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");
        }
    }
}
