using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallingNumber
{
    public class UpdateCDRCallingNumberCommandHandler : IRequestHandler<UpdateCDRCallingNumberCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRCallingNumberCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRCallingNumberCommandHandler(
            ILogger<UpdateCDRCallingNumberCommandHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateCDRCallingNumberCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateCallingNumberAsync(request.Id, request.CallingNumber);
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