using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumberConfirmed
{
    public class UpdateUserPhoneNumberConfirmedCommandHandler : IRequestHandler<UpdateUserPhoneNumberConfirmedCommand, Response<bool>>
    {
        private readonly ILogger<UpdateUserPhoneNumberConfirmedCommandHandler> _logger;
        private readonly IUserRepository _repository;
        public UpdateUserPhoneNumberConfirmedCommandHandler(
               ILogger<UpdateUserPhoneNumberConfirmedCommandHandler> logger,
               IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateUserPhoneNumberConfirmedCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdatePhoneNumberConfirmedAsync(request.Id, request.PhoneNumberConfirmed);
                if (result)
                    return new Response<bool>(result);
                return new Response<bool>(result, "Fucky wucky happened");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
