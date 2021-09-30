using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MishaTelecoms.API.Middleware;
using MishaTelecoms.API.Models.Requests.CDRData.Post.Create;
using MishaTelecoms.API.Models.Requests.CDRData.Post.Update;
using MishaTelecoms.Application.Common.Routes.ApiRoutes;
using MishaTelecoms.Application.Features.CDRData.Commands.Create;
using MishaTelecoms.Application.Features.CDRData.Commands.Delete;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateAll;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCalledNumber;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallingNumber;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallType;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCost;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCountry;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateDuration;
using MishaTelecoms.Application.Features.CDRData.Queries.GetAllCDR;
using MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByCallType;
using MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByCountry;
using MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByDateCreated;
using MishaTelecoms.Application.Features.CDRData.Queries.GetCDRById;
using System;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    /// <summary>
    /// CDRData Controller responsible for GET/POST/DELETE requests for CDRData
    /// </summary>

    [ApiKeyAuth]
    [ApiController]
    public class CDRController : BaseController
    {
        /// <summary>
        /// Inherits from BaseController Class
        ///     - Contains IMediator and IMapper Intefaces using Dependency Injection
        /// </summary>
        public CDRController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Action: Creates CDR Data entry in the database
        /// </summary>
        /// <response code="200">Creates CDR Data entry in the database</response>
        /// <response code="400">Unable to create the tag due to validation error</response>
        /// <returns>Boolean</returns>
        [HttpPost]
        [Route(ApiRoutes.CDRData.Base)]
        public async Task<IActionResult> Post([FromBody] CreateCDRRequest request)
        {
            var query = _mapper.Map<CreateCDRRequest, CreateCDRCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Action: Returns all CDRData entries in database
        /// </summary>
        /// <response code="200">Returns all the CDR Data  entries in the database</response>
        /// <returns>ReadOnlyList of CDRData Objects</returns>

        // [Authorize]
        [HttpGet]
        [Route(ApiRoutes.CDRData.Base)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCDRQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// url = api/CDRData/id={id}
        /// <summary>
        /// Returns CDRData with matching id
        /// </summary>
        /// <returns>CDRData Object</returns>
        [HttpGet(ApiRoutes.CDRData.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetCDRByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        /// <summary>
        /// Returns CDR Data matching Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.CDRData.GetByCountry)]
        public async Task<IActionResult> GetByCountry([FromRoute] string country)
        {
            var query = new GetCDRByCountryQuery(country);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Returns CDR Data matching Call Type
        /// </summary>
        /// <param name="calltype"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.CDRData.GetByCallType)]
        public async Task<IActionResult> GetByCallType([FromRoute] string calltype)
        {
            var query = new GetCDRByCallTypeQuery(calltype);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Returns CDR Data matching Call Type
        /// </summary>
        /// <param name="datecreated"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.CDRData.GetByDateCreated)]
        public async Task<IActionResult> GetByDateCreated([FromRoute] string datecreated)
        {
            var query = new GetCDRByDateCreatedQuery(datecreated);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates All properties of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateAll)]
        public async Task<IActionResult> Update([FromBody]UpdateCDRAllRequest request)
        {
            var query = _mapper.Map<UpdateCDRAllRequest, UpdateCDRAllCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates the CallingNumber of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateCallingNumber)]
        public async Task<IActionResult> UpdateCallingNumber([FromBody] UpdateCDRCallingNumberRequest request)
        {
            var query = _mapper.Map<UpdateCDRCallingNumberRequest, UpdateCDRCallingNumberCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates the CalledNumber of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateCalledNumber)]
        public async Task<IActionResult> UpdateCalledNumber([FromBody] UpdateCDRCalledNumberRequest request)
        {
            var query = _mapper.Map<UpdateCDRCalledNumberRequest, UpdateCDRCalledNumberCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates the Country of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateCountry)]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCDRCountryRequest request)
        {
            var query = _mapper.Map<UpdateCDRCountryRequest, UpdateCDRCountryCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates the CallType of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateCallType)]
        public async Task<IActionResult> UpdateCallType([FromBody] UpdateCDRCallTypeRequest request)
        {
            var query = _mapper.Map<UpdateCDRCallTypeRequest, UpdateCDRCallTypeCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates the Duration of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateDuration)]
        public async Task<IActionResult> Updateduration([FromBody] UpdateCDRDurationRequest request)
        {
            var query = _mapper.Map<UpdateCDRDurationRequest, UpdateCDRDurationCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Updates the Cost of a CDRData record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Boolean</returns>
        [HttpPatch(ApiRoutes.CDRData.UpdateCost)]
        public async Task<IActionResult> UpdateCost([FromBody] UpdateCDRCostRequest request)
        {
            var query = _mapper.Map<UpdateCDRCostRequest, UpdateCDRCostCommand>(request);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes CDRData with matching id
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete(ApiRoutes.CDRData.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var query = new DeleteCDRCommand(Id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
