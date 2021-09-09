using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByCallTypeQuery : IRequest<Response<IReadOnlyList<CDRDataDto>>>
    {
        public string CallType { get; set; }
        public GetCDRByCallTypeQuery(string callType)
        {
            CallType = callType;
        }
    }
}
