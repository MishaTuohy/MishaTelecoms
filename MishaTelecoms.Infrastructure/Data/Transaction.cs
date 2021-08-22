using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace MishaTelecoms.Infrastructure.Data
{
    public class Transaction : DatabaseUtils, IDisposable, ITransaction
    {
        [NonSerialized]
        DbConnection _connection;

        [NonSerialized]
        DbTransaction _transaction;

        public Transaction(DbConnectionConfig config) : base(config)
        {
            _connection = CreateConnection();
            _transaction = _connection.BeginTransaction();
        }
        public Transaction() : base(null)
        {
            _connection = CreateConnection();
            _transaction = _connection.BeginTransaction();
        }
        public DbConnection GetConnection()
        {
            return _connection;
        }
        public DbTransaction GetTransaction()
        {
            return _transaction;
        }
        public bool HasTransaction()
        {
            if (_connection == null || _transaction == null)
                return false;
            if (_connection.State != ConnectionState.Open)
                return false;
            return true;
        }
        public void Commit()
        {
            if (HasTransaction())
            {
                _transaction.Commit();
                _transaction.Dispose();
                _connection.Close();
                _connection.Dispose();
            }
        }
        public void Rollback()
        {
            if (HasTransaction())
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _connection.Close();
                _connection.Dispose();
            }
        }
        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}

