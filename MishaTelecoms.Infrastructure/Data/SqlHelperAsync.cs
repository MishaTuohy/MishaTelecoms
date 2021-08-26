using Dapper;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Utils;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Data
{
    public class SqlHelperAsync : DatabaseUtils, ISqlHelperAsync
    {
        private readonly string Connection;

        public SqlHelperAsync(DbConnectionConfig config) :
          base(config)
        {
            Connection = config.ConnectionString("DefaultConnection");
        }
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

        public async Task<T> GetRecordAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters p = new DynamicParameters();
            IEnumerable<T> result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        p.Add("@" + param.Name, param.Value);
                }
                result = await SqlMapper.QueryAsync<T>(_connection, sql, p, commandType: _commandType);
            }
            return result.FirstOrDefault();
        }

        public async Task<List<T>> GetRecordsAsync<T>(string sql, CommandType _commandType)
        {
            IEnumerable<T> result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                result = await SqlMapper.QueryAsync<T>(_connection, sql, commandType: _commandType, commandTimeout: 180);
            }
            return result.ToList();
        }

        public async Task<List<T>> GetRecordsParamAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();
            IEnumerable<T> result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }
                result = await SqlMapper.QueryAsync<T>(_connection, sql, _params, commandType: _commandType, commandTimeout: 180);
            }
            return result.ToList();
        }
    }
}
