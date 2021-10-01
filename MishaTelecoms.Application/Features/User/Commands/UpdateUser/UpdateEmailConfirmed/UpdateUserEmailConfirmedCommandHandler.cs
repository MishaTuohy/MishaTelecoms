using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmailConfirmed
{
    public class UpdateUserEmailConfirmedCommandHandler : IRequestHandler<UpdateUserEmailConfirmedCommand, Response<bool>>
    {
        private readonly ILogger<UpdateUserEmailConfirmedCommandHandler> _logger;
        private readonly IUserRepository _repository;
        public UpdateUserEmailConfirmedCommandHandler(
               ILogger<UpdateUserEmailConfirmedCommandHandler> logger,
               IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateUserEmailConfirmedCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateEmailConfirmedAsync(request.Id, request.EmailConfirmed);
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
