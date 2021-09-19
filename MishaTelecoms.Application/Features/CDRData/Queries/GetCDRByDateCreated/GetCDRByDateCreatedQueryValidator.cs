using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByDateCreated
{
    public class GetCDRByDateCreatedQueryValidator : AbstractValidator<GetCDRByDateCreatedQuery>
    {
        public GetCDRByDateCreatedQueryValidator()
        {
            RuleFor(r => r.DateCreated)
                .NotEmpty().WithMessage("DateCreated is required")
                .NotNull().WithMessage("DateCreated cannot be null")
                .MaximumLength(8).WithMessage("DateCreated must not exceed 10 characters.");
        }
    }
}
