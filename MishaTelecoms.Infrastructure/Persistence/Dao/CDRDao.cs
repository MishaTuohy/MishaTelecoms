using MishaTelecoms.Application.Interfaces.Dao;

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
                        Country, 
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
            return @"Select * From dbo.CDRData";
        }

        public string GetByIdSql()
        {
            return @"SELECT * FROM dbo.CDRData 
                    WHERE (id = @guid OR @guid IS NULL)";
        }

        public string GetByCountry()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE (Country = @Country OR @CountryId = '')";
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
