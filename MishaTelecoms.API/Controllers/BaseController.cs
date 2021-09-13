using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MishaTelecoms.API.Controllers
{
    public class BaseController : Controller
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
