using Microsoft.Extensions.Configuration;
using System;

namespace MishaTelecoms.Domain.Settings
{
    public class DbConnectionConfig
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString(string DatabaseReference) 
        {
            if (DatabaseReference is null)
                throw new ArgumentNullException(nameof(DatabaseReference));
            return Configuration.GetConnectionString(DatabaseReference);
        }
    }
}