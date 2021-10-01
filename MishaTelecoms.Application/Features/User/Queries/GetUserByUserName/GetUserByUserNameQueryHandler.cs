using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByUserName
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, Response<ApplicationUserDto>>
    {
        private readonly ILogger<GetUserByUserNameQueryHandler> _logger;
        private readonly IUserRepository _repository;
        public GetUserByUserNameQueryHandler(
            ILogger<GetUserByUserNameQueryHandler> logger,
            IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Response<ApplicationUserDto>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.GetByUserNameAsync(request.UserName);
                if (result is null)
                    return new Response<ApplicationUserDto>("Failed to retrieve Data");
                return new Response<ApplicationUserDto>(result, "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
