using MishaTelecoms.Domain.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Data
{
    public interface ISqlHelperAsync
    {
        // Executes asynchronous query
        Task<int> ExecuteQueryAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        // Used to execute command that returns a single value 
        Task<int> ExecuteScalarAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        // Executes a query that returns a single value
        Task<T> GetRecordAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
        // Executes a query that returns multiple queries
        Task<List<T>> GetRecordsAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
    }

}
