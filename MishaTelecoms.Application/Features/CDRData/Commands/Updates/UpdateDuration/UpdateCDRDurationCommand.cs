using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateDuration
{
    public class UpdateCDRDurationCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public int Duration { get; set; }
    }
}
