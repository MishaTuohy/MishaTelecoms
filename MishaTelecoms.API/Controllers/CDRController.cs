using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MishaTelecoms.API.Models.Requests;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Features.CDRData.Commands;
using MishaTelecoms.Application.Features.CDRData.Queries;
using System;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    /// <summary>
    /// CDRData Controller responsible for GET/POST/DELETE requests for CDRData
    /// </summary>
    [Route("api/cdrdata")]
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
        /// <param name="entity">CDR Data Object</param>
        /// <response code="200">Creates CDR Data entry in the database</response>
        /// <response code="400">Unable to create the tag due to validation error</response>
        /// <returns>Boolean</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CDRDataRequest entity)
        {
            var requestObject = _mapper.Map<CDRDataRequest, CDRDataDto>(entity);
            var query = new CreateCDRCommand(requestObject);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Action: Returns all CDRData entries in database
        /// </summary>
        /// <response code="200">Returns all the CDR Data  entries in the database</response>
        /// <returns>ReadOnlyList of CDRData Objects</returns>
        [HttpGet]
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
        [HttpGet("id={id}")]
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
        [HttpGet("country={country}")]
        public async Task<IActionResult> GetByCountry([FromRoute] string country)
        {
            var query = new GetCDRByCountryQuery(country);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Returns CDR Data matching Call Type
        /// </summary>
        /// <param name="callType"></param>
        /// <returns></returns>
        [HttpGet("calltype={callType}")]
        public async Task<IActionResult> GetByCallType([FromRoute] string callType)
        {
            var query = new GetCDRByCallTypeQuery(callType);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes CDRData with matching id
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete("delete/id={Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var query = new DeleteCDRCommand(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
