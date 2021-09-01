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
    [Route("api/[controller]")]
    [ApiController]
    public class CDRController : Controller
    {
        private readonly ICDRService _service;
        private readonly ILogger<CDRController> _logger;
        private readonly IMapper _mapper;

        public CDRController(
            ILogger<CDRController> logger,
            ICDRService cdrService, 
            IMapper mapper)
        {
            _logger = logger;
            _service = cdrService;
            _mapper = mapper;
        }

        // api/CDRData/
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

        // api/CDRData/
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
            }
            return null;
        }

        // api/CDRData/id/{id}
        [HttpGet("id/{id}")]
        public async Task<CDRDataModel> GetById([FromBody] Guid id)
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

        // api/CDRData/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete([FromBody] CDRDataModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                    return await _service.DeleteAsync(_mapper.Map<CDRDataModel, CDRDataDto>(entity));
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
