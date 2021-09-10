using MediatR;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands
{
    public class DeleteCDRCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public DeleteCDRCommand(Guid id)
        {
            Id = id;
        }
    }
}
