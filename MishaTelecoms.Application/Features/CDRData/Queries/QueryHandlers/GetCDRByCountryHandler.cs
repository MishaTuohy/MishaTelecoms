using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Queries.QueryHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByCountryHandler : IRequestHandler<GetCDRByCountryQuery, Response<IReadOnlyList<CDRDataDto>>>
    {
        private readonly ILogger<GetCDRByCountryHandler> _logger;
        private readonly ICDRRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        public GetCDRByCountryHandler(ILogger<GetCDRByCountryHandler> logger, ICDRRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<IReadOnlyList<CDRDataDto>>> Handle(GetCDRByCountryQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.GetByCountryAsync(request.Country);
                if (result.Count < 1)
                    return new Response<IReadOnlyList<CDRDataDto>>("Failed to retrieve Data");
                return new Response<IReadOnlyList<CDRDataDto>>(result, "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
