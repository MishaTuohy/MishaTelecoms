using MediatR;
using MishaTelecoms.API.Models.Responses;
using System.Collections.Generic;

namespace MishaTelecoms.API.Services.CDRServices.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByCallTypeQuery : IRequest<IReadOnlyList<CDRDataResponse>>
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
