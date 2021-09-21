using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallType
{
    public class UpdateCDRCallTypeCommandHandler : IRequestHandler<UpdateCDRCallTypeCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRCallTypeCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRCallTypeCommandHandler(
            ILogger<UpdateCDRCallTypeCommandHandler> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(UpdateCDRCallTypeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateCallTypeAsync(request.Id, request.CallType);
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