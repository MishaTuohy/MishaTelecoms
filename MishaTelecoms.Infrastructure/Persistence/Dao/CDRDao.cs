using MishaTelecoms.Application.Interfaces.Dao;

namespace MishaTelecoms.Infrastructure.Persistence.Dao
{
    public class CDRDao : ICDRDao
    {
        public string InsertSql()
        {
            return @"INSERT INTO [dbo].[CDRData] 
                        (Id, 
                        CallingNumber, 
                        CalledNumber, 
                        Country, 
                        CallType, 
                        Duration, 
                        DateCreated,
                        Cost)
                   VALUES 
                        (@Id, 
                        @CallingNumber, 
                        @CalledNumber, 
                        @Country, 
                        @CallType, 
                        @Duration,
                        @DateCreated,
                        @Cost);
                    SELECT SCOPE_IDENTITY()";
        }

        public string GetAllSql()
        {
            return @"Select * From [dbo].[CDRData] ";
        }

        public string GetByIdSql()
        {
            return @"SELECT * FROM [dbo].[CDRData] 
                    WHERE Id = @Id";
        }

        public string GetByCountry()
        {
            return @"SELECT * [dbo].[CDRData] 
                   WHERE (Country = @Country OR @Country = '')";
        }
        public string GetByCallType()
        {
            return @"SELECT * FROM [dbo].[CDRData] 
                   WHERE CallType = @CallType";
        }
        public string GetByDateCreated()
        {
            return @"SELECT * FROM [dbo].[CDRData] 
                   WHERE DateCreated = @DateCreated";
        }
        public string GetByDuration()
        {
            return @"SELECT * FROM [dbo].[CDRData] 
                   WHERE Duration = @Duration";
        }
        public string DeleteSql()
        {
            return @"DELETE FROM [dbo].[CDRData] 
                   WHERE Id = @Id";
        }
        public string UpdateAllSql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET CallingNumber = @Callingnumber, CalledNumber = @CalledNumber, Country = @Country,
                    CallType = @CallType, Duration = @Duration, DateCreated = @DateCreated, Cost = @Cost
                    WHERE Id = @Id";
        }
        public string UpdateCallingNumberSql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET CallingNumber = @CallingNumber
                    WHERE Id = @Id";
        }
        public string UpdateCalledNumberSql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET CalledNumber = @CalledNumber
                    WHERE Id = @Id";
        }
        public string UpdateCountrySql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET Country = @Country
                    WHERE Id = @Id";
        }
        public string UpdateCallTypeSql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET CallType = @CallType
                    WHERE Id = @Id";
        }
        public string UpdateDurationSql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET Duration = @Duration
                    WHERE Id = @Id";
        }

        public string UpdateDateCreatedSql()
        {
            return @"UPDATE [dbo].[CDRData]  
                    SET DateCreated = @DateCreated
                    WHERE Id = @Id";
        }

        public string UpdateCostSql()
        {
            return @"UPDATE [dbo].[CDRData] 
                    SET Cost = @Cost
                    WHERE Id = @Id";
        }
    }
}
