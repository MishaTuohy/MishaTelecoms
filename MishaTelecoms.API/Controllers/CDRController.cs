using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
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
        private readonly ICDRRepository _cdrRepository;
        private readonly ILogger<CDRController> _logger;

        public CDRController(ILogger<CDRController> logger, ICDRRepository cdrRepository)
        {
            _logger = logger;
            _cdrRepository = cdrRepository;
        }

        // api/CDRData/
        [Authorize]
        [HttpPost]
        public Task<bool> Post([FromBody] CDRDataDto entity)
        {
            try
            {
                if (ModelState.IsValid)
                    return _cdrRepository.AddAsync(entity);
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        // api/CDRData/
        [Authorize]
        [HttpGet]
        public Task<IReadOnlyList<CDRDataDto>> GetAll()
        {
            try
            {
                return _cdrRepository.GetAllAsync();
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
        public Task<CDRDataDto> GetById(Guid id)
        {
            try
            {
                return _cdrRepository.GetByIdAsync(id);
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
        public void Delete(CDRDataDto entity)
        {
            try
            {
                _cdrRepository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
