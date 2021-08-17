using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Dao
{
    public interface ICDRDao
    {
        string InsertSql();
        string GetAllSql();
        string GetAllWhereSql();
        string GetByIdSql();
        string DeleteSql();
    }
}
