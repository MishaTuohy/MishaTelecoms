using MishaTelecoms.Domain.Settings;
using System;
using System.Data.Common;
using System.Data.SqlClient;


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
            return _config.ConnectionString();
        }

        public DbConnection CreateConnection()
        {
            return CreateConnection(ConnectionString());
        }

        public DbConnection CreateConnection(string _connection)
        {
            if (_connection is null)
                throw new ArgumentNullException(nameof(_connection));

            // ** Factory pattern in action
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
            DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");


            var connection = factory.CreateConnection();
            connection.ConnectionString = _connection;
            connection.Open();
            return connection;
        }
    }
}
