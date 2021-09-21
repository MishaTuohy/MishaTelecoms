using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCalledNumber
{
    class UpdateCDRCalledNumberCommandHandler : IRequestHandler<UpdateCDRCalledNumberCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRCalledNumberCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRCalledNumberCommandHandler(
            ILogger<UpdateCDRCalledNumberCommandHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateCDRCalledNumberCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateCalledNumberAsync(request.Id, request.CalledNumber);
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
