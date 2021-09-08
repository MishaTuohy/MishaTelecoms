using MediatR;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Features.CDRData.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllCDRQuery : IRequest<Response<IReadOnlyList<CDRDataDto>>>
    {
    }

    //public class GetAllCDRHandler : IRequestHandler<GetAllCDRQuery, Response<IReadOnlyList<CDRDataDto>>>
    //{
    //    private readonly ILogger<GetAllCDRHandler> _logger;
    //    private readonly ICDRRepository _repository;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="logger"></param>
    //    /// <param name="repository"></param>
    //    public GetAllCDRHandler(ILogger<GetAllCDRHandler> logger, ICDRRepository repository)
    //    {
    //        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    //        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="request"></param>
    //    /// <param name="cancellationToken"></param>
    //    /// <returns></returns>
    //    public async Task<Response<IReadOnlyList<CDRDataDto>>> Handle(GetAllCDRQuery request, CancellationToken cancellationToken)
    //    {
    //        if (request is null)
    //            throw new ArgumentNullException(nameof(request));

    //        try
    //        {
    //            var result = await _repository.GetAllAsync();
    //            if (result == null)
    //                return null;
    //            return new Response<IReadOnlyList<CDRDataDto>>(result);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex.Message);
    //            throw;
    //        }
    //    }
    //}

}
