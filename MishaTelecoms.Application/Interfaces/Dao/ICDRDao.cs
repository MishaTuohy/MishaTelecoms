using MishaTelecoms.Domain.Data;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Interfaces.Dao
{
    public interface ICDRDao
    {
        string InsertSql();
        string GetAllSql();
        string GetByIdSql();
        string GetByCountry();
        string GetByCallType();
        string GetByDateCreated();
        string GetByDuration();
        string UpdateAllSql();
        string UpdateCallingNumberSql();
        string UpdateCalledNumberSql();
        string UpdateCountrySql();
        string UpdateCallTypeSql();
        string UpdateDurationSql();
        string UpdateDateCreatedSql();
        string UpdateCostSql();
        string DeleteSql();
    }
}
