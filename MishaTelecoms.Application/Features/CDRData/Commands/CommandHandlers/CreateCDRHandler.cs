using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CommandHandlers
{
    public class CreateCDRHandler : IRequestHandler<CreateCDRCommand, bool>
    {
        private readonly ILogger<CreateCDRHandler> _logger;
        private readonly ICDRRepository _repository;

        public CreateCDRHandler(
            ILogger<CreateCDRHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<bool> Handle(CreateCDRCommand request, CancellationToken cancellationToken)
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
