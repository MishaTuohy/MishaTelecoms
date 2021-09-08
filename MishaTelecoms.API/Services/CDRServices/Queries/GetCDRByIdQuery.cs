using MediatR;
using MishaTelecoms.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services.CDRServices.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByIdQuery : IRequest<CDRDataResponse>
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
