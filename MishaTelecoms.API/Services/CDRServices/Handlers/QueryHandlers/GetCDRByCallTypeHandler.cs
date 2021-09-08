using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Models.Responses;
using MishaTelecoms.API.Services.CDRServices.Queries;
using MishaTelecoms.Application.Dtos;
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
   public class GetCDRByCallTypeHandler : IRequestHandler<GetCDRByCallTypeQuery, IReadOnlyList<CDRDataResponse>>
    {
        private readonly ILogger<GetAllCDRHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICDRRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public GetCDRByCallTypeHandler(ILogger<GetAllCDRHandler> logger, IMapper mapper, ICDRRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<CDRDataResponse>> Handle(GetCDRByCallTypeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = _mapper.Map<IReadOnlyList<CDRDataDto>, IReadOnlyList<CDRDataResponse>>(await _repository.GetByCallTypeAsync(request.CallType));
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
