using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Models.Requests;
using MishaTelecoms.API.Services.CDRServices.Commands;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services.CDRServices.Handlers.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCDRHandler : IRequestHandler<CreateCDRCommand, bool>
    {
        private readonly ILogger<CreateCDRHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICDRRepository _repository;
        private readonly DbConnectionConfig _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="config"></param>
        public CreateCDRHandler(ILogger<CreateCDRHandler> logger, IMapper mapper, ICDRRepository repository,
            DbConnectionConfig config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async  Task<bool> Handle(CreateCDRCommand request, CancellationToken cancellationToken)
        {
            bool result;
            using (Transaction _trans = new Transaction(_config))
            {
                try
                {
                    result = await _repository.AddAsync(_trans, _mapper.Map<CDRDataRequest, CDRDataDto>(request.Entity));
                    if (result)
                        _trans.Commit();
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
            return result;
        }
    }
}
