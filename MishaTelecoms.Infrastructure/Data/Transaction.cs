using MishaTelecoms.Application.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MishaTelecoms.Infrastructure.Data
{
    public class Transaction : ITransaction
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DbConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        public DbTransaction GetTransaction()
        {
            throw new NotImplementedException();
        }

        public bool HasTransaction()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
