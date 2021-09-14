using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetAllCDR
{
    public class GetAllCDRQuery : IRequest<Response<IReadOnlyList<CDRDataDto>>>
    {
    }   
}
