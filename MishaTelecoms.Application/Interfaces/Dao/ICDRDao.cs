using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Dao
{
    public interface ICDRDao
    {
        // Insert CDR Data
        string InsertSql();
        // GetAll CDR Dat
        string GetAllSql();
        // Get CDR Data by Id
        string GetByIdSql();
        // Get CDR Data by Country
        string GetByCountry();
        // Get CDR Data by CallType
        string GetByCallType();
        // Get CDR Data by Duration
        string GetByDuration();
        // Update CDR Data entry
        string UpdateSql();
        // Delete CDR Data entry
        string DeleteSql();
    }
}
