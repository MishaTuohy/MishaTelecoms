using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Features.CDRData.Queries;
using MishaTelecoms.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services.CDRServices.Handlers.QueryHandlers
{
    /// <summary>
    /// 
    /// </summary>
   public class GetCDRByCallTypeHandler : IRequestHandler<GetCDRByCallTypeQuery, IReadOnlyList<CDRDataDto>>
    {
        private readonly ILogger<GetCDRByCallTypeHandler> _logger;
        private readonly ICDRRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        public GetCDRByCallTypeHandler(ILogger<GetCDRByCallTypeHandler> logger, ICDRRepository repository)
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
        public async Task<IReadOnlyList<CDRDataDto>> Handle(GetCDRByCallTypeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.GetByCallTypeAsync(request.CallType);
                if (result == null)
                    return null;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
