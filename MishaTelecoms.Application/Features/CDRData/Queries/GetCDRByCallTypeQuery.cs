using MediatR;
using MishaTelecoms.Application.Dtos;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByCallTypeQuery : IRequest<IReadOnlyList<CDRDataDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public string CallType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callType"></param>
        public GetCDRByCallTypeQuery(string callType)
        {
            CallType = callType;
        }
    }
}
