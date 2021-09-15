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
            // foreach (var param in parameters)
            //     Console.WriteLine(param.Name + " " +param.Value);
            // Console.WriteLine(sql);

            var result = await _connection.ExecuteScalarAsync<int>(sql, _params, transaction: _transaction, commandType: _commandType);
            return result;
        }

        public async Task<T> GetRecordAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            using IDbConnection _connection = CreateConnection();
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }

            return (await SqlMapper.QueryAsync<T>(_connection, sql, param: _params, commandType: _commandType, commandTimeout: 180)).FirstOrDefault();
        }

        public async Task<List<T>> GetRecordsAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            using IDbConnection _connection = CreateConnection();
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }

            return (await SqlMapper.QueryAsync<T>(_connection, sql, param: _params, commandType: _commandType, commandTimeout: 180)).ToList();
        }
    }
}
