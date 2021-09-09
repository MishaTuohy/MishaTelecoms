using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByIdQuery : IRequest<Response<CDRDataDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public GetCDRByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
