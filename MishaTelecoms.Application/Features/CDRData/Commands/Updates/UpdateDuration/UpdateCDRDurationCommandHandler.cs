using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateDuration
{
    public class UpdateCDRDurationCommandHandler : IRequestHandler<UpdateCDRDurationCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRDurationCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRDurationCommandHandler(
            ILogger<UpdateCDRDurationCommandHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateCDRDurationCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateDurationAsync(request.Id, request.Duration);
                return new Response<bool>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
