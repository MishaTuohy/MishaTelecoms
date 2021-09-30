using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateAll
{
    public class UpdateCDRAllCommandHandler : IRequestHandler<UpdateCDRAllCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRAllCommandHandler> _logger;
        private readonly ICDRRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCDRAllCommandHandler(
            ILogger<UpdateCDRAllCommandHandler> logger,
            ICDRRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateCDRAllCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var dto = _mapper.Map<UpdateCDRAllCommand, CDRDataDto>(request);
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
