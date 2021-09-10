using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    public class GetCDRByIdQuery : IRequest<Response<CDRDataDto>>
    {
        public Guid Id { get; }

        public GetCDRByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
