using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Services.CDRServices.Commands;
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
    public class DeleteCDRHandler : IRequestHandler<DeleteCDRCommand, bool>
    {
        private readonly ILogger<DeleteCDRHandler> _logger;
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
        public DeleteCDRHandler(ILogger<DeleteCDRHandler> logger, IMapper mapper, ICDRRepository repository,
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
        public async Task<bool> Handle(DeleteCDRCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
                throw new ArgumentNullException("Id can not be null");

            using (Transaction _trans = new Transaction(_config))
            {
                try
                {
                    var result = await _repository.DeleteAsync(_trans, request.Id);
                    if (result)
                        _trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
        }
    }
}
