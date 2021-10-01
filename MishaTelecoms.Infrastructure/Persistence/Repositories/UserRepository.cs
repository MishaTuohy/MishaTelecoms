using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ISqlHelperAsync _sqlHelper;
        private readonly ILogger<UserRepository> _logger;
        private readonly IUserDao dao;
        private readonly DbConnectionConfig _config;

        public UserRepository(IUserDao dao, ILogger<UserRepository> logger, ISqlHelperAsync sqlHelper, DbConnectionConfig config)
        {
            _sqlHelper = sqlHelper;
            _logger = logger;
            this.dao = dao;
            _config = config;
        }

        public async Task<bool> AddAsync(ApplicationUserDto user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            bool result = false;
            using (Transaction trans = new Transaction(_config))
            {
                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo {Name = "Id", Value = user.Id},
                        new ParameterInfo {Name = "UserName", Value = user.UserName},
                        new ParameterInfo {Name = "NormalizedUserName", Value = user.NormalizedUserName},
                        new ParameterInfo {Name = "Email", Value = user.Email},
                        new ParameterInfo {Name = "NormalizedEmail", Value = user.NormalizedEmail},
                        new ParameterInfo {Name = "EmailConfirmed", Value = user.EmailConfirmed},
                        new ParameterInfo {Name = "PasswordHash", Value = user.PasswordHash},
                        new ParameterInfo {Name = "PhoneNumber", Value = user.PhoneNumber},
                        new ParameterInfo {Name = "PhoneNumberConfirmed", Value = user.PhoneNumberConfirmed},
                        new ParameterInfo {Name = "TwoFactorEnabled", Value = user.TwoFactorEnabled}
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.InsertSql(), _params, CommandType.Text) > 0;

                    if(result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to create User");
                    throw;
                }
            }
            return result;
        }

        public async Task<IReadOnlyList<ApplicationUserDto>> GetAllAsync()
        {
            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo{ Name = "Id", Value = null }
                };
                return await _sqlHelper.GetRecordsAsync<ApplicationUserDto>(dao.GetAllSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retreive Users");
                throw;
            }
        }

        public async Task<ApplicationUserDto> GetByIdAsync(Guid Id)
        {
            if (Id == null)
                throw new ArgumentNullException("Id value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Id", Value = Id }
                };
                return await _sqlHelper.GetRecordAsync<ApplicationUserDto>(dao.GetByIdSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve User");
                throw;
            }
        }

        public async Task<ApplicationUserDto> GetByUserNameAsync(string UserName)
        {
            if (UserName == null)
                throw new ArgumentNullException("UserName value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "UserName", Value = UserName }
                };
                return await _sqlHelper.GetRecordAsync<ApplicationUserDto>(dao.GetByNameSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve User");
                throw;
            }
        }
        public async Task<ApplicationUserDto> GetByEmailAsync(string Email)
        {
            if (Email == null)
                throw new ArgumentNullException("Email value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "Email", Value = Email }
                };
                return await _sqlHelper.GetRecordAsync<ApplicationUserDto>(dao.GetByEmailSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve User");
                throw;
            }
        }
        public async Task<ApplicationUserDto> GetByPhoneNumberAsync(string PhoneNumber)
        {
            if (PhoneNumber == null)
                throw new ArgumentNullException("PhoneNumber value can't be empty");

            try
            {
                List<ParameterInfo> _params = new List<ParameterInfo>
                {
                    new ParameterInfo { Name = "PhoneNumber", Value = PhoneNumber }
                };
                return await _sqlHelper.GetRecordAsync<ApplicationUserDto>(dao.GetByPhoneNumberSql(), _params, CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve User");
                throw;
            }
        }

        public async Task<bool> UpdateAllAsync(ApplicationUserDto user)
        {
            if (user == null)
                throw new ArgumentNullException("CDR Data cannot be null");

            bool result;
            using (Transaction trans = new Transaction(_config))
            {
                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = user.Id },
                        new ParameterInfo { Name = "UserName", Value = user.UserName },
                        new ParameterInfo { Name = "NormalizedUserName", Value = user.NormalizedUserName } ,
                        new ParameterInfo { Name = "Email", Value =  user.Email },
                        new ParameterInfo { Name = "NormalizedEmail", Value = user.NormalizedEmail },
                        new ParameterInfo { Name = "EmailConfirmed", Value = user.EmailConfirmed },
                        new ParameterInfo { Name = "PasswordHash", Value = user.PasswordHash },
                        new ParameterInfo { Name = "PhoneNumber", Value = user.PhoneNumber },
                        new ParameterInfo { Name = "PhoneNumberConfirmed", Value =  user.PhoneNumberConfirmed },
                        new ParameterInfo { Name = "TwoFactorEnabled", Value =  user.TwoFactorEnabled }
                    };
                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateSql(), _params, CommandType.Text) > 0;

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

        public async Task<bool> UpdateUserNameAsync(Guid Id, string UserName)
        {
            if (UserName is null)
                throw new ArgumentNullException(nameof(UserName));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "UserName", Value = UserName }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateUserNameSql(), _params, CommandType.Text) > 0;

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

        public async Task<bool> UpdateNormalizedUserNameAsync(Guid Id, string NormalizedUserName)
        {
            if (NormalizedUserName is null)
                throw new ArgumentNullException(nameof(NormalizedUserName));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "NormalizedUserName", Value = NormalizedUserName }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateNormalizedUserNameSql(), _params, CommandType.Text) > 0;

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
                throw new ArgumentNullException("User Id cannot be null");

            bool result = false;

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
                    _logger.LogError(ex, "Failed to delete User");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdatePasswordHashAsync(Guid Id, string PasswordHash)
        {
            if (PasswordHash is null)
                throw new ArgumentNullException(nameof(PasswordHash));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "PasswordHash", Value = PasswordHash }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdatePasswordHashSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update PasswordHash");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateEmailAsync(Guid Id, string Email)
        {
            if (Email is null)
                throw new ArgumentNullException(nameof(Email));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "Email", Value = Email }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateEmailSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update Email");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateNormalizedEmailAsync(Guid Id, string NormalizedEmail)
        {
            if (NormalizedEmail is null)
                throw new ArgumentNullException(nameof(NormalizedEmail));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "NormalizedEmail", Value = NormalizedEmail }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateNormalizedEmailSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update NormalizedEmail");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateEmailConfirmedAsync(Guid Id, bool EmailConfirmed)
        {
            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "EmailConfirmed", Value = EmailConfirmed }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateEmailConfirmedSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update EmailConfirmed");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdatePhoneNumberAsync(Guid Id, string PhoneNumber)
        {
            if (PhoneNumber is null)
                throw new ArgumentNullException(nameof(PhoneNumber));

            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "PhoneNumber", Value = PhoneNumber }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdatePhoneNumberSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update PhoneNumber");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdatePhoneNumberConfirmedAsync(Guid Id, bool PhoneNumberConfirmed)
        {
            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "PhoneNumberConfirmed", Value = PhoneNumberConfirmed }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdatePhoneNumberConfirmedSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update PhoneNumberConfirmed");
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> UpdateTwoFactorEnabledAsync(Guid Id, bool TwoFactorEnabled)
        {
            bool result;

            using (Transaction trans = new Transaction(_config))
            {

                try
                {
                    List<ParameterInfo> _params = new List<ParameterInfo>
                    {
                        new ParameterInfo { Name = "Id", Value = Id },
                        new ParameterInfo { Name = "TwoFactorEnabled", Value = TwoFactorEnabled }
                    };

                    result = await _sqlHelper.ExecuteQueryAsync(trans.GetConnection(), trans.GetTransaction(), dao.UpdateTwoFactorEnabledSql(), _params, CommandType.Text) > 0;

                    if (result)
                        trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    _logger.LogError(ex, "Failed to update TwoFactorEnabled");
                    throw;
                }
            }
            return result;
        }
    }
}
