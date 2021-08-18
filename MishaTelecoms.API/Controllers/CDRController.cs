using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MishaTelecoms.API.Models;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Authorize]
        [HttpPost]
        public async Task<bool> Post([FromBody] CDRDataModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = _mapper.Map<CDRDataModel, CDRDataDto>(entity);
                    return await _service.AddAsync(dto);
                }                
                else
                {
                    return false;
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        // api/CDRData/
        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyList<CDRDataDto>> GetAll()
        {
            try
            {
                return null;// await _cdrRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        // api/CDRData/id/{id}
        [Authorize]
        [HttpGet("id/{id}")]
        public async Task<CDRDataDto> GetById(Guid id)
        {
            try
            {
                return null;// await _cdrRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        // api/CDRData/delete/{id}
        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(CDRDataDto entity)
        {
            try
            {
                return false;// await _cdrRepository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
