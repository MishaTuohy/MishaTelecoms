using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.UpdateCDR
{
    public class UpdateCDRCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string CallingNumber { get; set; }
        public string CalledNumber { get; set; }
        public string Country { get; set; }
        public string CallType { get; set; }
        public int Duration { get; set; }
        public string DateCreated { get; set; }
        public double Cost { get; set; }
    }
}
