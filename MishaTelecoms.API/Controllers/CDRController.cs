using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Data;
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
        private readonly ITransaction _transaction;

        public CDRController(ILogger<CDRController> logger, ICDRRepository cdrRepository, ITransaction transaction)
        {
            _transaction = transaction;
            _logger = logger;
            _cdrRepository = cdrRepository;
        }

        // api/CDRData/
        [Authorize]
        [HttpPost]
        public async Task<bool> Post([FromBody] CDRDataDto entity)
        {
            try
            {
                if (ModelState.IsValid)
                    return await _cdrRepository.AddAsync(_transaction, entity);
                throw new ArgumentNullException("CDR Data cannot be null");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Api Failure");
                throw;
            }
        }

        // api/CDRData/
        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyList<CDRDataDto>> GetAll()
        {
            try
            {
                return await _cdrRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Api Failure");
                throw;
            }
        }

        // api/CDRData/id/{id}
        [Authorize]
        [HttpGet("id/{id}")]
        public async Task<CDRDataDto> GetById(Guid Id)
        {
            try
            {
                if(Id == null)
                    throw new ArgumentNullException("CDR Data cannot be null");
                return await _cdrRepository.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Api Failure");
                throw;
            }
        }

        // api/CDRData/delete/{id}
        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(CDRDataDto entity)
        {       
            try
            {
                if (ModelState.IsValid)
                    return await _cdrRepository.DeleteAsync(entity);
                throw new ArgumentNullException("CDR Data cannot be null");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Api Failure");
                throw;
            }
        }
    }
}
