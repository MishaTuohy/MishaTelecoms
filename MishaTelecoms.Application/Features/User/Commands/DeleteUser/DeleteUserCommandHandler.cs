using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IUserRepository _repository;
        public DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
                throw new ArgumentNullException("Id can not be null");

            try
            {
                var result = await _repository.DeleteAsync(request.Id);
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
