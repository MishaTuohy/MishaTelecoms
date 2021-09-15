using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Commands.UpdateCDR
{
    public class UpdateCDRCommandHandler : IRequestHandler<UpdateCDRCommand, Response<bool>>
    {
        private readonly ILogger<UpdateCDRCommandHandler> _logger;
        private readonly ICDRRepository _repository;

        public UpdateCDRCommandHandler(ILogger<UpdateCDRCommandHandler> logger, ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public Task<Response<bool>> Handle(UpdateCDRCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            throw new NotImplementedException();
        }
    }
}
