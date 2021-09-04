﻿using Microsoft.Extensions.Logging;
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
    public class CDRService : ICDRService
    {
        private readonly ILogger<CDRService> _logger;
        private readonly ICDRRepository _repository;
        private readonly DbConnectionConfig _config;

        public CDRService(
            ILogger<CDRService> logger,
            ICDRRepository repository,
            DbConnectionConfig config)
        {
            _logger = logger;
            _repository = repository;
            _config = config;
        }

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

        public async Task<IReadOnlyList<CDRDataDto>> GetAllAsync()
        {
            
            using (Transaction _trans = new Transaction(_config))
            {
                try
                {
                    IReadOnlyList<CDRDataDto> result = await _repository.GetAllAsync(_trans);
                    if (result.Count() > 0)
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

        public async Task<CDRDataDto> GetByIdAsync(Guid Id)
        {
            if (Id == null)
                throw new ArgumentNullException("Id can not be null");
            using (Transaction _trans = new Transaction(_config))
            {
                try
                {
                    var result = await _repository.GetByIdAsync(_trans, Id);
                    if (result != null)
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

        public async Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(string Country, string CallType, int Duration)
        {
            if(Country == null || CallType == null)
                throw new ArgumentNullException("Country can not be null");
            if (CallType == null)
                throw new ArgumentNullException("Call Type can not be null");
            if (Duration <= 0)
                throw new ArgumentException("Duration can not be a 0 or a negative number");

            using (Transaction _trans = new Transaction(_config))
            {
                try
                {
                    var result = await _repository.GetFilteredCDRDataAsync(_trans, Country, CallType, Duration);
                    if (result.Count() > 0)
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