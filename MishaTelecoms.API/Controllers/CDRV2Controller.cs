using MediatR;
using Microsoft.AspNetCore.Mvc;
using MishaTelecoms.API.Models;
using MishaTelecoms.API.Services.CDRServices.Commands;
using MishaTelecoms.API.Services.CDRServices.Queries;
using System;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    /// <summary>
    /// CDRData Controller responsible for GET/POST/DELETE requests for managing CDRData
    /// </summary>
    [Route("api/cdrdataV2")]
    [ApiController]
    public class CDRV2Controller : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public CDRV2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// url = /api/CDRData
        /// <summary>
        /// Create a CDRData entry in the database
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CDRDataModel entity)
        {
            var query = new CreateCDRCommand();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// url = /api/cdrdata
        /// <summary>
        /// Returns all CDRData entries in database
        /// </summary>
        /// <returns>ReadOnlyList of CDRData Objects</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCDRQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
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
        /// 
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
        /// 
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

        /// url = api/CDRData/delete/{id}
        /// <summary>
        /// Deletes CDRData with matching id
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete("delete/id={id}")]
        public async Task<IActionResult> Delete([FromRoute] CDRDataModel entity)
        {
            var query = new DeleteCDRCommand();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
