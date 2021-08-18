using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Dao
{
    public interface ICDRDao
    {
        string InsertSql();
        string GetAllSql();
        string GetByIdSql();
        string GetByCountry();
        string GetByCallType();
        string GetByDuration();
        string GetFilteredCdrDataSql();
        string UpdateSql();
        string DeleteSql();
    }
}
