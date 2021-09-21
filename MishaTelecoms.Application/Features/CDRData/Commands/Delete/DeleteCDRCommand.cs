using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Delete
{
    public class DeleteCDRCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public DeleteCDRCommand(Guid id)
        {
            Id = id;
        }
    }
}
