using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IReadOnlyList<ApplicationUserDto>>>
    {
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        private readonly IUserRepository _repository;
        public GetAllUsersQueryHandler(
            ILogger<GetAllUsersQueryHandler> logger,
            IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<IReadOnlyList<ApplicationUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var result = await _repository.GetAllAsync();
                if (result.Count < 1)
                    return new Response<IReadOnlyList<ApplicationUserDto>>("Failed to retrieve Data");
                return new Response<IReadOnlyList<ApplicationUserDto>>(result, "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
