using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByCountry
{
    public class GetCDRByCountryQueryValidator : AbstractValidator<GetCDRByCountryQuery>
    {
        public GetCDRByCountryQueryValidator()
        {
            RuleFor(r => r.Country)
                .NotEmpty().WithMessage("Country is required")
                .NotNull().WithMessage("Country cannot be null")
                .MaximumLength(8).WithMessage("Country must not exceed 10 characters.");
        }
    }
}
