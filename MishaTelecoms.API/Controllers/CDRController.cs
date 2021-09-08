using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Models;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    /// <summary>
    /// CDRData Controller responsible for GET/POST/DELETE requests for managing CDRData
    /// </summary>
    [Route("api/CDRData")]
    [ApiController]
    public class CDRController : Controller
    {
        private readonly ICDRService _service;
        private readonly ILogger<CDRController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cdrService"></param>
        /// <param name="mapper"></param>
        public CDRController(
            ILogger<CDRController> logger,
            ICDRService cdrService, 
            IMapper mapper)
        {
            _logger = logger;
            _service = cdrService;
            _mapper = mapper;
        }

        /// url = /api/CDRData
        /// <summary>
        /// Create a CDRData entry in the database
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpPost]
        public async Task<bool> Post([FromBody] CDRDataModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                    return await _service.AddAsync(_mapper.Map<CDRDataModel, CDRDataDto>(entity));
                return false;      
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        /// url = /api/cdrdata
        /// <summary>
        /// Returns all CDRData entries in database
        /// </summary>
        /// <returns>ReadOnlyList of CDRData Objects</returns>
        [HttpGet]
        public async Task<IReadOnlyList<CDRDataModel>> GetAll()
        {
            try
            {
                return _mapper.Map<IReadOnlyList<CDRDataDto>, IReadOnlyList<CDRDataModel>>(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// url = api/CDRData/id={id}
        /// <summary>
        /// Returns CDRData with matching id
        /// </summary>
        /// <returns>CDRData Object</returns>
        [HttpGet("id={id}")]
        public async Task<CDRDataModel> GetById([FromRoute] Guid id)
        {
            try
            {
                return _mapper.Map<CDRDataDto, CDRDataModel>(await _service.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        /// url = api/CDRData/delete/{id}
        /// <summary>
        /// Deletes CDRData with matching id
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete("delete/id={id}")]
        public async Task<bool> Delete([FromRoute] Guid Id)
        {
            try
            {
                if (ModelState.IsValid)
                    return await _service.DeleteAsync(Id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
