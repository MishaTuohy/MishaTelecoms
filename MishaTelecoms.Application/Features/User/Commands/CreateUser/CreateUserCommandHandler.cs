using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<bool>>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            ILogger<CreateUserCommandHandler> logger,
            IUserRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException("Create User Request cannot be null");

            try
            {
                var dto = _mapper.Map<CreateUserCommand, ApplicationUserDto>(request);
                var result = await _repository.AddAsync(dto);
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
