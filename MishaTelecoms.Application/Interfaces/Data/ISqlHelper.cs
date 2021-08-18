using MishaTelecoms.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Data
{
    public interface ISqlHelper
    {
        int ExecuteQuery(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        int ExecuteQuery(string sql, List<ParameterInfo> parameters, CommandType _commandType, int CommandTimeout);
        Task<int> ExecuteQueryAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        Task<int> ExecuteScalarAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType);
        T GetRecord<T>(string spName, List<ParameterInfo> parameters, CommandType _commandType);
        List<T> GetRecords<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
        Task<T> GetRecordAsync<T>(string spName, List<ParameterInfo> parameters, CommandType _commandType);
        Task<List<T>> GetRecordsAsync<T>(string sql, CommandType _commandType);
        Task<List<T>> GetRecordsParamAsync<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
    }
}
