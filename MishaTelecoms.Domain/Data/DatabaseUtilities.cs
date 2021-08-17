﻿using MishaTelecoms.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MishaTelecoms.Domain.Data
{
    public class DatabaseUtilities
    {
        private readonly DbConnectionConfig _config;

        public DatabaseUtilities(DbConnectionConfig config)
        {
            _config = config;
        }

        public string ConnectionString()
        {
            return _config.ConnectionString;
        }

        public DbConnection CreateConnection(string _connection)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            var connection = factory.CreateConnection();
            connection.ConnectionString = _connection;
            connection.Open();
            return connection;
        }
    }
}