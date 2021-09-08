using MediatR;
using MishaTelecoms.API.Models.Responses;
using System.Collections.Generic;

namespace MishaTelecoms.API.Services.CDRServices.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllCDRQuery : IRequest<IReadOnlyList<CDRDataResponse>>
    {
    }
}
