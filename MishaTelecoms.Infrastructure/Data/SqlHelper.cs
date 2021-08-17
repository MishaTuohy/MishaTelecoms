using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Data
{
    public class SqlHelper : ISqlHelper
    {
        public int ExecuteQuery(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            throw new NotImplementedException();
        }

        public int ExecuteQuery(string sql, List<ParameterInfo> parameters, CommandType _commandType, int CommandTimeout)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteScalarAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            throw new NotImplementedException();
        }

        public T GetRecord<T>(string spName, List<ParameterInfo> parameters, CommandType _commandType)
        {
            throw new NotImplementedException();
        }

        public List<T> GetRecords<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            throw new NotImplementedException();
        }
    }
}
