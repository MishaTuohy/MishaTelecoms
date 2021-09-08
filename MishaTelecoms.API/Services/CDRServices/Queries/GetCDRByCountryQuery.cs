using MediatR;
using MishaTelecoms.API.Models.Responses;
using System.Collections.Generic;

namespace MishaTelecoms.API.Services.CDRServices.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByCountryQuery : IRequest<IReadOnlyList<CDRDataResponse>>
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
