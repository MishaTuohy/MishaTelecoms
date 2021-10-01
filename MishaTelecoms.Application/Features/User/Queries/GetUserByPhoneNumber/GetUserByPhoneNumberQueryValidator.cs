using FluentValidation;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByPhoneNumber
{
    public class GetUserByPhoneNumberQueryValidator : AbstractValidator<GetUserByPhoneNumberQuery>
    {
        public GetUserByPhoneNumberQueryValidator()
        {
            RuleFor(r => r.PhoneNumber).NotNull()
                .WithMessage("PhoneNumber cannot be null");
        }
    }
}
