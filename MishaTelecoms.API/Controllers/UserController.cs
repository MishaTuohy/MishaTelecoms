using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MishaTelecoms.API.Middleware;
using MishaTelecoms.API.Models.Requests.UserData.Post.Create;
using MishaTelecoms.API.Models.Requests.UserData.Post.Delete;
using MishaTelecoms.API.Models.Requests.UserData.Post.Update;
using MishaTelecoms.Application.Common.Routes.ApiRoutes;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Features.User.Commands.CreateUser;
using MishaTelecoms.Application.Features.User.Commands.DeleteUser;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateAll;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmail;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmailConfirmed;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedEmail;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedUserName;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePassword;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumber;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumberConfirmed;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateTwoFactorEnabled;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateUserName;
using MishaTelecoms.Application.Features.User.Queries.GetAllUsers;
using MishaTelecoms.Application.Features.User.Queries.GetUserByEmail;
using MishaTelecoms.Application.Features.User.Queries.GetUserById;
using MishaTelecoms.Application.Features.User.Queries.GetUserByPhoneNumber;
using MishaTelecoms.Application.Features.User.Queries.GetUserByUserName;
using System;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    /// <summary>
    /// User Controller responsible for GET/POST/DELETE requests for User data
    /// </summary>
    
    // [ApiKeyAuth]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Action: Creates User Data entry in the database
        /// </summary>
        /// <response code="200">Creates User Data entry in the database</response>
        /// <response code="400">Unable to create the tag due to validation error</response>
        /// <returns>Boolean</returns>
        
        [HttpPost(ApiRoutes.User.Base)]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            var query = _mapper.Map<CreateUserRequest, CreateUserCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.User.Base)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.User.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.User.GetByUserName)]
        public async Task<IActionResult> GetByUserName([FromRoute] string username)
        {
            var query = new GetUserByUserNameQuery(username);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.User.GetByEmail)]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var query = new GetUserByEmailQuery(email);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet(ApiRoutes.User.GetByPhoneNumber)]
        public async Task<IActionResult> GetByPhoneNumber([FromRoute] string PhoneNumber)
        {
            var query = new GetUserByPhoneNumberQuery(PhoneNumber);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateAll)]
        public async Task<IActionResult> Update([FromBody] UpdateUserAllRequest request)
        {
            var query = _mapper.Map<UpdateUserAllRequest, UpdateUserAllCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateUserName)]
        public async Task<IActionResult> UpdateUserName([FromBody] UpdateUserNameRequest request)
        {
            var query = _mapper.Map<UpdateUserNameRequest, UpdateUserUserNameCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateNormalizedUserName)]
        public async Task<IActionResult> UpdateNormalizedUserName([FromBody] UpdateUserNormalizedUserNameRequest request)
        {
            var query = _mapper.Map<UpdateUserNormalizedUserNameRequest, UpdateUserNormalizedUserNameCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateEmail)]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateUserEmailRequest request)
        {
            var query = _mapper.Map<UpdateUserEmailRequest, UpdateUserEmailCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateNormalizedEmail)]
        public async Task<IActionResult> UpdateNormalizedEmail([FromBody] UpdateUserNormalizedEmailRequest request)
        {
            var query = _mapper.Map<UpdateUserNormalizedEmailRequest, UpdateUserNormalizedEmailCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateEmailConfirmed)]
        public async Task<IActionResult> UpdateEmailconfirmed([FromBody] UpdateUserEmailConfirmedRequest request)
        {
            var query = _mapper.Map<UpdateUserEmailConfirmedRequest, UpdateUserEmailConfirmedCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdatePhoneNumber)]
        public async Task<IActionResult> UpdatePhoneNumber([FromBody] UpdateUserPhoneNumberRequest request)
        {
            var query = _mapper.Map<UpdateUserPhoneNumberRequest, UpdateUserPhoneNumberCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdatePhoneNumberConfirmed)]
        public async Task<IActionResult> UpdatePhonenumberConfirmed([FromBody] UpdateUserPhoneNumberConfirmedRequest request)
        {
            var query = _mapper.Map<UpdateUserPhoneNumberConfirmedRequest, UpdateUserPhoneNumberConfirmedCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdatePasswordHash)]
        public async Task<IActionResult> UpdatePasswordHash([FromBody] UpdateUserPasswordHashRequest request)
        {
            var query = _mapper.Map<UpdateUserPasswordHashRequest, UpdateUserPasswordCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPatch(ApiRoutes.User.UpdateTwoFactorEnabled)]
        public async Task<IActionResult> UpdateTwoFactorEnabled([FromBody] UpdateUserTwoFactorEnabledRequest request)
        {
            var query = _mapper.Map<UpdateUserTwoFactorEnabledRequest, UpdateUserTwoFactorEnabledCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete(ApiRoutes.User.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var query = new DeleteUserCommand(Id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
