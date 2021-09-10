using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.CommandHandlers
{
    public class DeleteCDRHandler : IRequestHandler<DeleteCDRCommand, bool>
    {
        private readonly ILogger<DeleteCDRHandler> _logger;
        private readonly ICDRRepository _repository;
        public DeleteCDRHandler(ILogger<DeleteCDRHandler> logger, ICDRRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteCDRCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
                throw new ArgumentNullException("Id can not be null");

            try
            {
                return await _repository.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
