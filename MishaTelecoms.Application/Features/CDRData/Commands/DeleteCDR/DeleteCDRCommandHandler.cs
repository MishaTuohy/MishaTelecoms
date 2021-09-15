using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.DeleteCDR
{
    public class DeleteCDRCommandHandler : IRequestHandler<DeleteCDRCommand, bool>
    {
        private readonly ILogger<DeleteCDRCommandHandler> _logger;
        private readonly ICDRRepository _repository;
        public DeleteCDRCommandHandler(ILogger<DeleteCDRCommandHandler> logger, ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
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
