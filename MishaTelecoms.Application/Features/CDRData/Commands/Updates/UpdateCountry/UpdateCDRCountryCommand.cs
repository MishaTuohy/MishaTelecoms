using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCountry
{
    public class UpdateCDRCountryCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
    }
}