using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CreateCDR
{
    public class CreateCDRCommand : IRequest<Response<bool>>
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
