using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Data
{
    public interface ITransaction
    {
        void Commit();
        void Dispose();
        DbConnection GetConnection();
        DbTransaction GetTransaction();
        bool HasTransaction();
        void Rollback();
    }
}
