using Dapper;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Data
{
    public class SqlHelper : DatabaseUtilities, ISqlHelper
    {
        private readonly string Connection;

        public SqlHelper(DbConnectionConfig config) :
          base(config)
        {
            Connection = config.ConnectionString;
        }
        public int ExecuteQuery(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }

            int iRetVal = SqlMapper.Execute(_connection, sql, _params, transaction: _transaction, commandType: _commandType);

            return iRetVal;
        }

        public int ExecuteQuery(string sql, List<ParameterInfo> parameters, CommandType _commandType, int CommandTimeout)
        {
            int iRetVal = 0;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                DynamicParameters _params = new DynamicParameters();

                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }

                iRetVal = SqlMapper.Execute(_connection, sql, _params, commandType: _commandType);
            }

            return iRetVal;
        }

        public async Task<int> ExecuteScalarAsync(IDbConnection _connection, IDbTransaction _transaction, string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            DynamicParameters _params = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var param in parameters)
                    _params.Add("@" + param.Name, param.Value);
            }

            int iRetVal = await _connection.ExecuteScalarAsync<int>(sql, _params, transaction: _transaction, commandType: _commandType);
            return iRetVal;
        }

        public T GetRecord<T>(string spName, List<ParameterInfo> parameters, CommandType _commandType)
        {
            T _record = default;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                DynamicParameters p = new DynamicParameters();

                if (parameters != null)
                {
                    foreach (var param in parameters)
                        p.Add("@" + param.Name, param.Value);
                }

                _record = SqlMapper.Query<T>(_connection, spName, p, commandType: _commandType).FirstOrDefault();
            }
            return _record;
        }

        public List<T> GetRecords<T>(string sql, List<ParameterInfo> parameters, CommandType _commandType)
        {
            List<T> lstValues = new List<T>();
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                DynamicParameters _params = new DynamicParameters();

                if (parameters != null)
                {
                    foreach (var param in parameters)
                        _params.Add("@" + param.Name, param.Value);
                }

                lstValues = SqlMapper.Query<T>(_connection, sql, _params, commandType: _commandType, commandTimeout: 180).ToList();
            }
            return lstValues;
        }
    }
}
