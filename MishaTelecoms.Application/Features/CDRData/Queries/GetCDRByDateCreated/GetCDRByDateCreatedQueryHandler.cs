using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByDateCreated
{
    public class GetCDRByDateCreatedQueryHandler : IRequestHandler<GetCDRByDateCreatedQuery, Response<IReadOnlyList<CDRDataDto>>>
    {
        private readonly ILogger<GetCDRByDateCreatedQueryHandler> _logger;
        private readonly ICDRRepository _repository;

        public GetCDRByDateCreatedQueryHandler(ILogger<GetCDRByDateCreatedQueryHandler> logger, ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<IReadOnlyList<CDRDataDto>>> Handle(GetCDRByDateCreatedQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var dateCreated = request.DateCreated;
                var result = await _repository.GetByDateCreatedAsync(dateCreated);

                if (result.Count < 1)
                    return new Response<IReadOnlyList<CDRDataDto>>("Failed to retreive Data");
                return new Response<IReadOnlyList<CDRDataDto>>(result, "Data retreived successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
