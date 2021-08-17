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

        public async Task<bool> AddAsync(CDRDataDto entity)
        {
            bool result = false;
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        result = await _connection.ExecuteAsync(dao.InsertSql(), entity, transaction: transaction) > 0;
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback();
                        return result;
                    }
                }
            }
        }

        public async Task<CDRDataDto> GetByIdAsync(Guid id)
        {
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                string sqlQuery = @"SELECT * FROM dbo.CDRData WHERE id = @guid";
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        var result = await _connection.QueryAsync<CDRDataDto>(sqlQuery, new { id }, transaction);
                        transaction.Commit();
                        return result.FirstOrDefault();
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

        public async Task<IReadOnlyList<CDRDataDto>> GetAllAsync()
        {
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        var result = await _connection.QueryAsync<CDRDataDto>("Select * From dbo.CDRData");
                        transaction.Commit();
                        return result.ToList();
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

        public Task UpdateAsync(CDRDataDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(CDRDataDto entity)
        {
            using (IDbConnection _connection = CreateConnection(Connection))
            {
                string sqlQuery = @"DELETE FROM dbo.CDRData WHERE id = @id";
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        await _connection.ExecuteAsync(sqlQuery, new { entity.Id }, transaction);
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
