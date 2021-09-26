using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Domain.Settings;

namespace MishaTelecoms.API.Dependencies.ConfigDependencies
{
    public static class DbConnectionConfiguration
    {
        public static IServiceCollection AddDbConnectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Assign your config so you can reuse it in Data layer
            var dbConnectionConfig = new DbConnectionConfig();
            configuration.GetSection("DbConnectionConfig").Bind(dbConnectionConfig);
            services.AddSingleton(dbConnectionConfig);
            return services;
        }
    }
}
