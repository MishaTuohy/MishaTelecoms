using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCost
{
    public class UpdateCDRCostCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public double Cost { get; set; }
    }
}
