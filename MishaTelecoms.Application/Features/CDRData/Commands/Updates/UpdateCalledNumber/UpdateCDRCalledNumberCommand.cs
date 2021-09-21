using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCalledNumber
{
    public class UpdateCDRCalledNumberCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string CalledNumber { get; set; }
    }
}
