using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MishaTelecoms.API.Models.Requests.UserData.Post;
using MishaTelecoms.Application.Dtos;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            var query = _mapper.Map<CreateUserRequest, UserDataDto>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
