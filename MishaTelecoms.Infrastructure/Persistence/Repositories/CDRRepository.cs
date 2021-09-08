﻿using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Persistence.Repositories
{
    public class CDRRepository : ICDRRepository
    {
        private readonly ISqlHelperAsync _sqlHelper;
        private readonly ILogger<CDRRepository> _logger;
        private readonly ICDRDao dao;
        public CDRRepository(ICDRDao dao, ILogger<CDRRepository> logger, ISqlHelperAsync sqlHelper)
        {
            _sqlHelper = sqlHelper;
            _logger = logger;
            this.dao = dao;
        }

        public async Task<bool> AddAsync(ITransaction trans, CDRDataDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("CDR Data cannot be null");

            bool result;
            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Id", Value = dto.Id },
                    new ParameterInfo { Name = "CallingNumber", Value = dto.CallingNumber } ,
                    new ParameterInfo { Name = "CalledNumber", Value =  dto.CalledNumber },
                    new ParameterInfo { Name = "Country", Value =dto.Country },
                    new ParameterInfo { Name = "CallType", Value = dto.CallType },
                    new ParameterInfo { Name = "Duration", Value = dto.Duration },
                    new ParameterInfo { Name = "DateCreated", Value = dto.DateCreated },
                    new ParameterInfo { Name = "Cost", Value =  dto.Cost },
                };
                result = await _sqlHelper.ExecuteScalarAsync(trans.GetConnection(), trans.GetTransaction(), dao.InsertSql(), _params, CommandType.Text) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create CDR Data");
                throw;
            }
            return result;
        }
        public async Task<IReadOnlyList<CDRDataDto>> GetAllAsync()
        {
            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo{ Name = "Id", Value = null }
                };
                return await _sqlHelper.GetRecordsAsync<CDRDataDto>(dao.GetAllSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retreive CDR Data");
                throw;
            }
        }
        public async Task<CDRDataDto> GetByIdAsync(Guid Id)
        {
            if(Id == null)
                throw new ArgumentNullException("Id value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Id", Value = Id }
                };
                return await _sqlHelper.GetRecordAsync<CDRDataDto>(dao.GetByIdSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve CDR Data");
                throw;
            }
        }
        public async Task<IReadOnlyList<CDRDataDto>> GetByCountryAsync(string Country)
        {
            if (Country == null)
                throw new ArgumentNullException("Country value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Country", Value = Country }
                };
                return await _sqlHelper.GetRecordsAsync<CDRDataDto>(dao.GetByCountry(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve CDR Data");
                throw;
            }
        }

        public async Task<IReadOnlyList<CDRDataDto>> GetByCallTypeAsync(string CallType)
        {
            if (CallType == null)
                throw new ArgumentNullException("CallType value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "CallType", Value = CallType }
                };
                return await _sqlHelper.GetRecordsAsync<CDRDataDto>(dao.GetByCallType(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve CDR Data");
                throw;
            }
        }

        public async Task<IReadOnlyList<CDRDataDto>> GetByCountryCallTypeDurationAsync(string Country, string CallType, int Duration)
        {
            if (Country == null | CallType == null | Duration < 0)
                throw new ArgumentNullException("Filter values can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Country", Value = Country },
                    new ParameterInfo { Name = "CallType", Value = CallType },
                    new ParameterInfo { Name = "Duration", Value = Duration }
                };
                return await _sqlHelper.GetRecordsParamAsync<CDRDataDto>(dao.GetFilteredCdrDataSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create CDR Data");
                throw;
            }
        }
        
        public async Task<bool> UpdateAsync(ITransaction trans ,CDRDataDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("CDR Data cannot be null");
            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Id", Value = dto.Id },
                    new ParameterInfo { Name = "CallingNumber", Value = dto.CallingNumber } ,
                    new ParameterInfo { Name = "CalledNumber", Value =  dto.CalledNumber },
                    new ParameterInfo { Name = "Country", Value =dto.Country },
                    new ParameterInfo { Name = "CallType", Value = dto.CallType },
                    new ParameterInfo { Name = "Duration", Value = dto.Duration },
                    new ParameterInfo { Name = "DateCreated", Value = dto.DateCreated },
                    new ParameterInfo { Name = "Cost", Value =  dto.Cost },
                };

                return await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateSql(), _params, CommandType.Text) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update CDR Data");
                throw;
            }
        }
        public async Task<bool> DeleteAsync(ITransaction trans, Guid Id)
        {
            if (Id == null)
                throw new ArgumentNullException("Id cannot be null");
            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Id", Value = Id }
                };
                return await _sqlHelper.ExecuteScalarAsync(trans.GetConnection(), trans.GetTransaction(), dao.DeleteSql(), _params, CommandType.Text) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create CDR Data");
                return false;
                throw;
            }
        }
    }
}
