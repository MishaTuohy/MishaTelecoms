using MishaTelecoms.Application.Interfaces.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Infrastructure.Data
{
    public class CDRDao : ICDRDao
    {
        public string GetAllSql()
        {
            throw new NotImplementedException();
        }

        public string GetAllWhere()
        {
            throw new NotImplementedException();
        }

        public string InsertSql()
        {
            return @"INSERT INTO dbo.CDRData (Id, CallingNumber, CalledNumber, Country, CallType, Duration, Cost)
                   VALUES (@id, @callingNumber, @calledNumber, @country, @callType, @duration, @cost)";
        }
    }
}
