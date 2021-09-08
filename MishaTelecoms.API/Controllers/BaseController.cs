using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MishaTelecoms.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
