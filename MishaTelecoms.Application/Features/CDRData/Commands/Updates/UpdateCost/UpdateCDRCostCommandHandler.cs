using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCost
{
    public class UpdateCDRCostCommandHandler : IRequestHandler<UpdateCDRCostCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRCostCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRCostCommandHandler(
            ILogger<UpdateCDRCostCommandHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateCDRCostCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateCostAsync(request.Id, request.Cost);
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
