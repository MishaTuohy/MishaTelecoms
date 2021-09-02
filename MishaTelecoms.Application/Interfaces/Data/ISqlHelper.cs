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
        T GetRecord<T>(string spName, List<ParameterInfo> parameters, CommandType _commandType);
        List<T> GetRecords<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
        List<T> GetRecordsParam<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType);
    }
}