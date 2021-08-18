﻿using MishaTelecoms.Application.Interfaces.Dao;
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
                        (Id, 
                        CallingNumber, 
                        CalledNumber, 
                        Cuntry, 
                        CallType, 
                        Duration, 
                        Cost)
                   VALUES 
                        (@Id, 
                        @CallingNumber, 
                        @CalledNumber, 
                        @Country, 
                        @CallType, 
                        @Duration, 
                        @Cost)";
        }
        public string GetAllSql()
        {
            return "Select * From dbo.CDRData";
        }
        public string GetByIdSql()
        {
            return @"SELECT * FROM dbo.CDRData 
                    WHERE Id = @Id";
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
                   WHERE Id = @id";
        }
        public string UpdateSql()
        {
            return @"UPDATE FROM dbo.CDRData
                   SET 
                        (Id = @Id, 
                        CallingNumber = @CallingNumber, 
                        CalledNumber = @CalledNumber, 
                        Country = @Country, 
                        CallType = @CallType, 
                        Duration = @Duration, 
                        Cost = @Cost)";
        }
    }
}
