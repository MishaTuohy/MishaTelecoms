using MediatR;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.DeleteCDR
{
    public class DeleteCDRCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteCDRCommand(Guid id)
        {
            Id = id;
        }
    }
}
