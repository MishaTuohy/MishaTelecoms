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
                        @Cost);
                    SELECT SCOPE_IDENTITY()";
        }

        public string GetAllSql()
        {
            return @"Select * From dbo.CDRData";
        }

        public string GetByIdSql()
        {
            return @"SELECT * FROM dbo.CDRData 
                    WHERE Id = @Id";
        }

        public string GetByCountry()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE (Country = @Country OR @Country = '')";
        }
        public string GetByCallType()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE CallType = @CallType";
        }
        public string GetByDateCreated()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE DateCreated = @DateCreated";
        }
        public string GetByDuration()
        {
            return @"SELECT * FROM dbo.CDRData
                   WHERE Duration = @Duration";
        }
        public string DeleteSql()
        {
            return @"DELETE FROM dbo.CDRData 
                   WHERE Id = @Id";
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
