using Dapper;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Data
{
    public class SqlHelperAsync : DatabaseUtils, ISqlHelperAsync
    {
        public SqlHelperAsync(DbConnectionConfig config) : base(config) {}

        public async Task<int> ExecuteQueryAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }

            return await SqlMapper.ExecuteAsync(_connection, sql, _params, transaction: _transaction, commandType: _commandType);
        }

        public async Task<int> ExecuteScalarAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }
            return await _connection.ExecuteScalarAsync<int>(sql, _params, transaction: _transaction, commandType: _commandType);
        }

        //  public async Task<T> GetRecordAsync<T>(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        //  {
        //      DynamicParameters _params = new DynamicParameters();
        //      if (parameters != null)
        //      {
        //          foreach (var param in parameters)
        //              _params.Add("@" + param.Name, param.Value);
        //      }
        //     return (await SqlMapper.QueryAsync<T>(_connection, sql, _params, _transaction, commandType: _commandType)).FirstOrDefault();
        //  }

        public async Task<T> GetRecordAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            using (IDbConnection _connection = CreateConnection())
            {
                DynamicParameters _params = new DynamicParameters();
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }
                return (await SqlMapper.QueryAsync<T>(_connection, sql, param: _params, commandType: _commandType, commandTimeout: 180)).FirstOrDefault();
            }
        }

        //  public async Task<List<T>> GetRecordsAsync<T>(IDbConnection _connection, IDbTransaction _transaction,  string sql, List<ParameterInfo> parameters, CommandType _commandType)
        //  {
        //      DynamicParameters _params = new DynamicParameters();
        //      if (parameters != null)
        //      {
        //      foreach (var param in parameters)
        //          _params.Add("@" + param.Name, param.Value);
        //      }
        //      return (await SqlMapper.QueryAsync<T>(_connection, sql, transaction: _transaction, param: _params, commandType: _commandType, commandTimeout: 180)).ToList();
        //  }

        public async Task<List<T>> GetRecordsAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            using (IDbConnection _connection = CreateConnection())
            {
                DynamicParameters _params = new DynamicParameters();
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }
                return (await SqlMapper.QueryAsync<T>(_connection, sql, param: _params, commandType: _commandType, commandTimeout: 180)).ToList();
            }
        }

        public async Task<List<T>> GetRecordsParamAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            using (IDbConnection _connection = CreateConnection())
            {
                DynamicParameters _params = new DynamicParameters();
                if (parameters == null)
                    throw new ArgumentNullException("Parameters cannot be null");

                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);

                return (await SqlMapper.QueryAsync<T>(_connection, sql, param: _params, commandType: _commandType, commandTimeout: 180)).ToList();
            }
        }
    }
}
