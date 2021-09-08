using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CDRService : ICDRService
    {
        private readonly ILogger<CDRService> _logger;
        private readonly ICDRRepository _repository;
        private readonly DbConnectionConfig _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="config"></param>
        public CDRService(
            ILogger<CDRService> logger,
            ICDRRepository repository,
            DbConnectionConfig config)
        {
            _logger = logger;
            _repository = repository;
            _config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(CDRDataDto entity)
        {
            bool result;

            if (entity == null)
                throw new ArgumentNullException("CDR Data can not be null");

            using (Transaction _trans = new Transaction(_config))
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<CDRDataDto>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<CDRDataDto> GetByIdAsync(Guid Id)
        {
            if (Id == null)
                throw new ArgumentNullException("Id can not be null");
            try
            {
                return await _repository.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<CDRDataDto>> GetByCountryAsync(string Country)
        {
            if (Country is null)
                throw new ArgumentNullException(nameof(Country));

            try
            {
                return await _repository.GetByCountryAsync(Country); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CallType"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<CDRDataDto>> GetByCallTypeAsync(string CallType)
        {
            if (CallType is null)
                throw new ArgumentNullException(nameof(CallType));

            try
            {
                return await _repository.GetByCallTypeAsync(CallType); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        /// <param name="CallType"></param>
        /// <param name="Duration"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(string Country, string CallType, int Duration)
        {
            if (Country == null)
                throw new ArgumentNullException("Country can not be null");
            if (CallType == null)
                throw new ArgumentNullException("Call Type can not be null");
            if (Duration <= 0)
                throw new ArgumentException("Duration can not be a 0 or a negative number");

            try
            {
                return await _repository.GetByCountryCallTypeDurationAsync(Country, CallType, Duration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(CDRDataDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException("CDR Data can not be null");

            using (Transaction _trans = new Transaction(_config))
            {
                try
                {
                    var result = await _repository.DeleteAsync(_trans, entity);
                    if (result)
                        _trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
        }
    }
}
