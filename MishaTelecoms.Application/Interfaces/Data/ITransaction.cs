using System.Data.Common;

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
