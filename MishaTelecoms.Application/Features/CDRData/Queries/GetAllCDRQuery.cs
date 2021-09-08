using MediatR;
using MishaTelecoms.Application.Dtos;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllCDRQuery : IRequest<IReadOnlyList<CDRDataDto>>
    {
    }
}
