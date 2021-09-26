using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.Create
{
    public class CreateCDRCommandHandler : IRequestHandler<CreateCDRCommand, Response<bool>>
    {
        private readonly ILogger<CreateCDRCommandHandler> _logger;
        private readonly ICDRRepository _repository;
        private readonly IMapper _mapper;

        public CreateCDRCommandHandler(
            ILogger<CreateCDRCommandHandler> logger,
            ICDRRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateCDRCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException("Create CDR Request cannot be null");

            try
            {
                var dto = _mapper.Map<CreateCDRCommand, CDRDataDto>(request);
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