using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Features.CDRData.Commands;
using MishaTelecoms.Application.Interfaces.Repositories;
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
        private readonly ICDRRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="config"></param>
        public CreateCDRHandler(
            ILogger<CreateCDRHandler> logger, 
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async  Task<bool> Handle(CreateCDRCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.AddAsync(request.CDR);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
