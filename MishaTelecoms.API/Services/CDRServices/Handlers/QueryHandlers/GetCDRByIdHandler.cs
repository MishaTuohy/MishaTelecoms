using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Models.Responses;
using MishaTelecoms.API.Services.CDRServices.Queries;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services.CDRServices.Handlers.QueryHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCDRByIdHandler : IRequestHandler<GetCDRByIdQuery, CDRDataResponse>
    {
        private readonly ILogger<GetCDRByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICDRRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="config"></param>
        public GetCDRByIdHandler(
            ILogger<GetCDRByIdHandler> logger, 
            IMapper mapper,
            ICDRRepository repository)
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
        public async Task<CDRDataResponse> Handle(GetCDRByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = _mapper.Map<CDRDataDto, CDRDataResponse>(await _repository.GetByIdAsync(request.Id));
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
