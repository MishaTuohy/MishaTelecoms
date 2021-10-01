using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Dao
{
    public interface IUserDao
    {
        string InsertSql();
        string DeleteSql();
        string GetAllSql();
        string GetByIdSql();
        string GetByNameSql();
        string GetByEmailSql();
        string GetByPhoneNumberSql();
        string UpdateSql();
        string UpdateUserNameSql();
        string UpdateNormalizedUserNameSql();
        string UpdateEmailSql();
        string UpdateNormalizedEmailSql();
        string UpdateEmailConfirmedSql();
        string UpdatePhoneNumberSql();
        string UpdatePhoneNumberConfirmedSql();
        string UpdatePasswordHashSql();
        string UpdateTwoFactorEnabledSql();
    }
}
