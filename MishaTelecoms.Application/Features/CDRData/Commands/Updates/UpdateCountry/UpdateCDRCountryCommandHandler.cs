using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCountry
{
    public class UpdateCDRCountryCommandHandler : IRequestHandler<UpdateCDRCountryCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRCountryCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRCountryCommandHandler(
            ILogger<UpdateCDRCountryCommandHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateCDRCountryCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateCountryAsync(request.Id, request.Country);
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
