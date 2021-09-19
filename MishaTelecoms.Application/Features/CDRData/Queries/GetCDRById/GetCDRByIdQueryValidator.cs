using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetCDRById
{
    public class GetCDRByIdQueryValidator : AbstractValidator<GetCDRByIdQuery>
    {
        public GetCDRByIdQueryValidator()
        {
            RuleFor(r => r.Id).NotNull()
                .WithMessage("Guid cannot be null");
        }
    }
}
