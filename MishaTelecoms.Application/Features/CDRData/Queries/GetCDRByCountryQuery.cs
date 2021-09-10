using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    public class GetCDRByCountryQuery : IRequest<Response<IReadOnlyList<CDRDataDto>>>
    {
        public string Country { get; set; }

        public GetCDRByCountryQuery(string country)
        {
            Country = country;
        }
    }
}
