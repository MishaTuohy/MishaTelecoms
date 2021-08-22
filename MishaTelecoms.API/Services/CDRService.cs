using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services
{
    public class CDRService : ICDRService
    {
        private readonly ILogger<CDRService> _logger;
        private readonly ICDRRepository _repository;

        public CDRService(
            ILogger<CDRService> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<bool> AddAsync(CDRDataDto entity)
        {
            bool result;

            if (entity == null)
                throw new ArgumentNullException("CDR Data can not be null");

            using (Transaction _trans = new Transaction())
            {
                try
                {
                    result = await _repository.AddAsync(_trans, entity);

                    if (result)
                        _trans.Commit();
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
            return result;
        }

        public async Task<IReadOnlyList<CDRDataDto>> GetAllAsync()
        {
            IReadOnlyList<CDRDataDto> result;
            using (Transaction _trans = new Transaction())
            {
                try
                {
                    result = await _repository.GetAllAsync();
                    if (result.Count() > 0)
                        _trans.Commit();
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
            return result;
        }

        public async Task<CDRDataDto> GetByIdAsync(Guid Id)
        {
            if (Id == null)
                throw new ArgumentNullException("Id can not be null");
            CDRDataDto result;
            using (Transaction _trans = new Transaction())
            {
                try
                {
                    result = await _repository.GetByIdAsync(Id);
                    if (result != null)
                        _trans.Commit();
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
            return result;
        }

        public async Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(string Country, string CallType, int Duration)
        {
            if(Country == null || CallType == null)
                throw new ArgumentNullException("Filter Types cannot be null");
            if (Duration <= 0)
                throw new ArgumentException("Duration can not be a 0 or a negative number");

            IEnumerable<CDRDataDto> result;
            using (Transaction _trans = new Transaction())
            {
                try
                {
                    result = await _repository.GetFilteredCDRDataAsync(Country, CallType, Duration);
                    if (result.Count() > 0)
                        _trans.Commit();
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> DeleteAsync(CDRDataDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException("CDR Data can not be null");

            bool result;
            using (Transaction _trans = new Transaction())
            {
                try
                {
                    result = await _repository.DeleteAsync(_trans, entity);

                    if (result)
                        _trans.Commit();
                    
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
            return result;
        }
    }
}
