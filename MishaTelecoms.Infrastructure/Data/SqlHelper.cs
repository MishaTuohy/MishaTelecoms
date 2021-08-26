using Dapper;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Utils;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MishaTelecoms.Infrastructure.Data
{
    public class SqlHelper : DatabaseUtils, ISqlHelper
    {
        private readonly string Connection;

        public SqlHelper(DbConnectionConfig config) :
          base(config)
        {
            Connection = config.ConnectionString("DefaultConnection");
        }

        public int ExecuteQuery(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }

            return SqlMapper.Execute(_connection, sql, _params, transaction: _transaction, commandType: _commandType);
        }
        
        public int ExecuteQuery(string sql, List<ParameterInfo> parameters, CommandType _commandType, int CommandTimeout)
        {
            DynamicParameters _params = new DynamicParameters();
            int result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }
                result = SqlMapper.Execute(_connection, sql, _params, commandType: _commandType);
            }
            return result;
        }
        
        public T GetRecord<T>(string spName, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters p = new DynamicParameters();
            T result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        p.Add("@" + param.Name, param.Value);
                }
                result = SqlMapper.Query<T>(_connection, spName, p, commandType: _commandType).FirstOrDefault();
            }
            return result;
        }
        
        public List<T> GetRecords<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();
            List<T> result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }
                result = SqlMapper.Query<T>(_connection, sql, _params, commandType: _commandType, commandTimeout: 180).ToList();
            }

            return result;
        }

        public List<T> GetRecordsParam<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();
            List<T> result;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }
                result = SqlMapper.Query<T>(_connection, sql, _params, commandType: _commandType, commandTimeout: 180).ToList();
            }
            return result;
        }
    }
}