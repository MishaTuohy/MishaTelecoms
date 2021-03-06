using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Data;
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
        private readonly DbConnectionConfig _config;

        public CDRRepository(ICDRDao dao, ILogger<CDRRepository> logger, ISqlHelperAsync sqlHelper, DbConnectionConfig config)
        {
            _sqlHelper = sqlHelper;
            _logger = logger;
            this.dao = dao;
            _config = config;
        }

        public async Task<bool> AddAsync(CDRDataDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("CDR Data cannot be null");

            bool result;
            using (Transaction trans = new Transaction(_config))
            {
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

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.InsertSql(), _params, CommandType.Text) > 0;

                    if(result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to create CDR Data");
                    throw;
                }
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
            if (Id == null)
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
        public async Task<IReadOnlyList<CDRDataDto>> GetByDateCreatedAsync(string DateCreated)
        {
            if (DateCreated == null)
                throw new ArgumentNullException("DateCreated value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "DateCreated", Value = DateCreated }
                };
                return await _sqlHelper.GetRecordsAsync<CDRDataDto>(dao.GetByDateCreated(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve CDR Data");
                throw;
            }
        }

        public async Task<bool> UpdateAllAsync(CDRDataDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("CDR Data cannot be null");

            bool result;
            using (Transaction trans = new Transaction(_config))
            {
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

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateAllSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateCallingNumberAsync(Guid Id, string CallingNumber)
        {
            if (CallingNumber is null)
                throw new ArgumentNullException(nameof(CallingNumber));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "CallingNumber", Value = CallingNumber }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateCallingNumberSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateCalledNumberAsync(Guid Id, string CalledNumber)
        {
            if (CalledNumber is null)
                throw new ArgumentNullException(nameof(CalledNumber));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "CalledNumber", Value = CalledNumber}
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateCalledNumberSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateCountryAsync(Guid Id, string Country)
        {
            if (Country is null)
                throw new ArgumentNullException(nameof(Country));
            bool result;
            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "Country", Value = Country}
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateCountrySql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateCallTypeAsync(Guid Id, string CallType)
        {
            if (CallType is null)
                throw new ArgumentNullException(nameof(CallType));
            bool result;
            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "CallType", Value = CallType}
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateCallTypeSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateDurationAsync(Guid Id, int Duration)
        {
            if (Duration <= 0)
                throw new ArgumentException(nameof(Duration));
            bool result;
            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "Duration", Value = Duration}
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateDurationSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateCostAsync(Guid Id, double Cost)
        {
            if (Cost <= 0.0)
                throw new ArgumentNullException(nameof(Cost));
            bool result;
            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "Cost", Value = Cost}
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateCostSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update CDR Data");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            if (Id == null)
                throw new ArgumentNullException("Id cannot be null");
            bool result;
            using (Transaction trans = new Transaction(_config))
            {
                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id }
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.DeleteSql(), _params, CommandType.Text) > 0;
                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to delete CDR Data");
                    throw;
                }
            }
            return result;
        }
    }
}
