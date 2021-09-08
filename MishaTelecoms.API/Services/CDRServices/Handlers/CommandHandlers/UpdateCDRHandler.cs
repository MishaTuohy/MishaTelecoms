using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Services.CDRServices.Commands;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Domain.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services.CDRServices.Handlers.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCDRHandler : IRequestHandler<UpdateCDRCommand, bool>
    {
        private readonly ILogger<UpdateCDRHandler> _logger;
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
        public UpdateCDRHandler(ILogger<UpdateCDRHandler> logger, IMapper mapper, ICDRRepository repository,
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
        public Task<bool> Handle(UpdateCDRCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            throw new System.NotImplementedException();
        }
    }
}
