using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCDRHandler : IRequestHandler<UpdateCDRCommand, bool>
    {
        private readonly ILogger<UpdateCDRHandler> _logger;
        private readonly ICDRRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="config"></param>
        public UpdateCDRHandler(ILogger<UpdateCDRHandler> logger, ICDRRepository repository)
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
        public Task<bool> Handle(UpdateCDRCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            throw new NotImplementedException();
        }
    }
}
