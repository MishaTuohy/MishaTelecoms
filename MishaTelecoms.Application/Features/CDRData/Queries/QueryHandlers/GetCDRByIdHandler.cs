using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Queries.QueryHandlers
{
    public class GetCDRByIdHandler : IRequestHandler<GetCDRByIdQuery, Response<CDRDataDto>>
    {
        private readonly ILogger<GetCDRByIdHandler> _logger;
        private readonly ICDRRepository _repository;

        public GetCDRByIdHandler(
            ILogger<GetCDRByIdHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CDRDataDto>> Handle(GetCDRByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var id = request.Id;
                var result = await _repository.GetByIdAsync(id);
                if (result is null)
                    return new Response<CDRDataDto>("Failed to retrieve Data");
                return new Response<CDRDataDto>(result, "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
