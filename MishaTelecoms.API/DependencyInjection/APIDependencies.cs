using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Infrastructure;
using MishaTelecoms.Domain.Settings;
using System;

namespace MishaTelecoms.API.DependencyInjection
{
    public static class APIDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            // Assign your config so you can reuse it in Data layer
            var dbConnectionConfig = new DbConnectionConfig();
            configuration.GetSection("DbConnectionConfig").Bind(dbConnectionConfig);
            services.AddSingleton(dbConnectionConfig);
            services.AddSwaggerDp();
            // Hook up infrastructure dependancies
            services.AddInfrastructure(configuration);
            
            return services;
        }
    }
}
