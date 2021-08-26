using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MishaTelecoms.CDRGenerator.Importers
{
    public class DbImporter : ICDRImporter<CDRDataDto>
    {
        private readonly string _connection;
        private readonly ICDRDao dao;
        private readonly ILogger<DbImporter> _logger;

        public DbImporter(ILogger<DbImporter> logger, DbConnectionConfig DbConfig, ICDRDao dao)
        {
            _connection = DbConfig.ConnectionString("DefaultConnection");
            this.dao = dao;
            _logger = logger;
        }

        public int SendToDB(List<CDRDataDto> CDRDataList)
        {
            if(CDRDataList.Count() <= 0)
                throw new ArgumentNullException("CDR Data cannot be null");

            try
            {
                int result = 0;
                foreach (CDRDataDto entity in CDRDataList)
                {
                    using var connection = new SqlConnection(_connection);
                        using var cmd = new SqlCommand(dao.InsertSql(), connection);
                            connection.Open();

                            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = entity.Id;
                            cmd.Parameters.Add("@CallingNumber", SqlDbType.VarChar, 20).Value = entity.CallingNumber;
                            cmd.Parameters.Add("@CalledNumber", SqlDbType.VarChar, 20).Value = entity.CalledNumber;
                            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 20).Value = entity.Country;
                            cmd.Parameters.Add("@CallType", SqlDbType.VarChar, 10).Value = entity.CallType;
                            cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = entity.Duration;
                            cmd.Parameters.Add("@DateCreated", SqlDbType.Int).Value = entity.DateCreated;
                            cmd.Parameters.Add("@Cost", SqlDbType.Money).Value = entity.Cost;

                            connection.Open();
                            result += cmd.ExecuteNonQuery();
                            connection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}