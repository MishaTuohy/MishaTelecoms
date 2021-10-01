using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateUserName
{
    public class UpdateUserUserNameCommandHandler : IRequestHandler<UpdateUserUserNameCommand, Response<bool>>
    {
        private readonly ILogger<UpdateUserUserNameCommandHandler> _logger;
        private readonly IUserRepository _repository;
        public UpdateUserUserNameCommandHandler(
               ILogger<UpdateUserUserNameCommandHandler> logger,
               IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateUserUserNameCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.UpdateUserNameAsync(request.Id, request.UserName);
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
