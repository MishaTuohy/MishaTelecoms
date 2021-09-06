using MishaTelecoms.Domain.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Data
{
    public interface ISqlHelperAsync
    {
        Task<int> ExecuteQueryAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        Task<int> ExecuteScalarAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        // Task<T> GetRecordAsync<T>(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        Task<T> GetRecordAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
        // Task<List<T>> GetRecordsAsync<T>(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        Task<List<T>> GetRecordsParamAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
        Task<List<T>> GetRecordsAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
    }

}
