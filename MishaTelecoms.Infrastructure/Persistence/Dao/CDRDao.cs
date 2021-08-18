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
            return @"INSERT INTO dbo.CDRData 
                        (id, 
                        callingNumber, 
                        calledNumber, 
                        country, 
                        callType, 
                        duration, 
                        cost)
                   VALUES 
                        (@id, 
                        @callingNumber, 
                        @calledNumber, 
                        @country, 
                        @callType, 
                        @duration, 
                        @cost)";
        }
        public string GetAllSql()
        {
            return "Select * From dbo.CDRData";
        }
        public string GetByIdSql()
        {
            return @"SELECT * FROM dbo.CDRData 
                    WHERE id = @guid";
        }
        public string GetByCountry()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE Country = @Country";
        }
        public string GetByCallType()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE Country = @Country";
        }
        public string GetByDuration()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE Country = @Country";
        }
        public string GetFilteredCdrDataSql()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE 
                        (Country = @Country AND
                        CallType = @CallType AND
                        Duration = @Duration)";
        }
        public string DeleteSql()
        {
            return @"DELETE FROM dbo.CDRData 
                   WHERE id = @id";
        }
        public string UpdateSql()
        {
            return @"UPDATE FROM dbo.CDRData
                   SET 
                        (id = @id, 
                        callingNumber = @callingNumber, 
                        calledNumber = @calledNumber, 
                        country = @country, 
                        callType = @callType, 
                        duration = @duration, 
                        cost = @cost)";
        }
    }
}
