using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateAll
{
    public class UpdateUserAllCommandHandler : IRequestHandler<UpdateUserAllCommand, Response<bool>>
    {
        private readonly ILogger<UpdateUserAllCommandHandler> _logger;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UpdateUserAllCommandHandler(
               ILogger<UpdateUserAllCommandHandler> logger,
               IUserRepository repository,
               IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateUserAllCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var dto = _mapper.Map<UpdateUserAllCommand, ApplicationUserDto>(request);
                var result = await _repository.UpdateAllAsync(dto);
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
