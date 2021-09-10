using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CommandHandlers
{
    public class UpdateCDRHandler : IRequestHandler<UpdateCDRCommand, bool>
    {
        private readonly ILogger<UpdateCDRHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRHandler(ILogger<UpdateCDRHandler> logger, ICDRRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<bool> Handle(UpdateCDRCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            throw new NotImplementedException();
        }
    }
}
