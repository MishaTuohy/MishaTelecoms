using MediatR;
using MishaTelecoms.Application.Dtos;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByCountryQuery : IRequest<IReadOnlyList<CDRDataDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        public GetCDRByCountryQuery(string country)
        {
            Country = country;
        }
    }
}
