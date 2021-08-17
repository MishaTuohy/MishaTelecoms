using MishaTelecoms.Application.Interfaces.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Infrastructure.Persistence.Dao
{
    public class CDRDao : ICDRDao
    {
        public string InsertSql()
        {
            return @"INSERT INTO dbo.CDRData (id, callingNumber, calledNumber, country, callType, duration, cost)
                   VALUES (@id, @callingNumber, @calledNumber, @country, @callType, @duration, @cost)";
        }
        public string GetAllSql()
        {
            return "Select * From dbo.CDRData";
        }

        public string GetAllWhereSql()
        {
            throw new NotImplementedException();
        }

        public string GetByIdSql()
        {
            return @"SELECT * FROM dbo.CDRData WHERE id = @guid";
        }

        public string DeleteSql()
        {
            return @"DELETE FROM dbo.CDRData WHERE id = @id";
        }
    }
}
