using MishaTelecoms.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MishaTelecoms.Infrastructure.Utils
{
    public class DatabaseUtils
    { 
        private readonly DbConnectionConfig _config;

    public DatabaseUtils(DbConnectionConfig config)
    {
        _config = config;
    }

    public string ConnectionString()
    {
        return _config.ConnectionString;
    }

    public DbConnection CreateConnection()
    {
        return CreateConnection(ConnectionString());
    }

    public DbConnection CreateConnection(string _connection)
    {
        // ** Factory pattern in action
        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        var connection = factory.CreateConnection();
        connection.ConnectionString = _connection;
        connection.Open();
        return connection;
    }
}
}
