using Dapper;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Domain.Data;
using MishaTelecoms.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Infrastructure.Persistence.Repositories
{
    public class CDRRepository : DatabaseUtilities, ICDRRepository
    {
        private readonly string Connection;
        private readonly ICDRDao dao;
        public CDRRepository(DbConnectionConfig config, ICDRDao dao) 
            : base(config)
        {
            Connection = config.ConnectionString;
            this.dao = dao;
        }

        public bool Create(CDRDataDto entity)
        {
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        _connection.Execute(dao.InsertSql(), entity, transaction: transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<CDRDataDto> GetAll()
        {
            using(IDbConnection _connection = CreateConnection(Connection))
            {
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        return _connection.Query<CDRDataDto>("Select * From dbo.CDRData").ToList();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback();
                        return null;
                    }
                }
            }
        }
        public CDRDataDto GetById(Guid id)
        {
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                string sqlQuery = @"SELECT * FROM dbo.CDRData WHERE id = @guid";
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        CDRDataDto result = _connection.Query<CDRDataDto>(sqlQuery, new { id }, transaction).FirstOrDefault();
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback();
                        return null;
                    }
                }
            }
        }

        public CDRDataDto Update(CDRDataDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                string sqlQuery = @"DELETE FROM dbo.CDRData WHERE id = @id";
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        _connection.Execute(sqlQuery, new { id }, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
