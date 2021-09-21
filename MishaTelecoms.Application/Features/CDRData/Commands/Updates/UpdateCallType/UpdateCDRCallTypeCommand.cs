using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallType
{
    public class UpdateCDRCallTypeCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string CallType { get; set; }
    }
}
