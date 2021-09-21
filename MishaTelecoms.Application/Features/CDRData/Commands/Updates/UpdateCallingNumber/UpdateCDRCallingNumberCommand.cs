using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallingNumber
{
    public class UpdateCDRCallingNumberCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string CallingNumber { get; set; }
    }
}