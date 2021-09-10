using MishaTelecoms.Domain.Settings;
using System;
using System.Data.Common;


namespace MishaTelecoms.Infrastructure.Utils
{
    // Database Utilities Class for creating connection to a database
    public class DatabaseUtils
    { 
        private readonly DbConnectionConfig _config;

        public DatabaseUtils(DbConnectionConfig config)
        {
            _config = config;
        }

        // Retrieves Connection string to database
        public string ConnectionString()
        {
            return _config.ConnectionString;
        }

        // Creates connection to database
        public DbConnection CreateConnection()
        {
            return CreateConnection(ConnectionString());
        }

        // Creates connection to database
        public DbConnection CreateConnection(string _connection)
        {
            if (_connection is null)
                throw new ArgumentNullException(nameof(_connection));

            DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");

            var connection = factory.CreateConnection();
            connection.ConnectionString = _connection;
            connection.Open();
            return connection;
        }
    }
}
