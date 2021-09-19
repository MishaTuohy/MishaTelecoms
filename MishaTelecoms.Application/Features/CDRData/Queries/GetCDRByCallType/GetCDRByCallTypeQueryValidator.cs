using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByCallType
{
    public class GetCDRByCallTypeQueryValidator : AbstractValidator<GetCDRByCallTypeQuery>
    {
        public GetCDRByCallTypeQueryValidator()
        {
            RuleFor(r => r.CallType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("CallType cannot be null")
                .MaximumLength(5).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
