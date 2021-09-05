using Microsoft.Extensions.Configuration;
using System;

namespace MishaTelecoms.Domain.Settings
{
    public class DbConnectionConfig
    {
        public string ConnectionString { get; set; }


        //public IConfiguration Configuration { get; set; }
        //public string ConnectionString()
        //{
        //    return Configuration.GetConnectionString("DefaultConnection");
        //}
    }
}