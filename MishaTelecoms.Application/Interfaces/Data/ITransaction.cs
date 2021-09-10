using System.Data.Common;

namespace MishaTelecoms.Application.Interfaces.Data
{
    public interface ITransaction
    {
        // Commits Transaction
        void Commit();
        // Disposes of resources
        void Dispose();
        // Gets DbConnection
        DbConnection GetConnection();
        // Gets DbTransaction
        DbTransaction GetTransaction();
        // Checks for a transaction
        bool HasTransaction();
        // Rolls back transaction, returns to orginal state
        void Rollback();
    }
}
