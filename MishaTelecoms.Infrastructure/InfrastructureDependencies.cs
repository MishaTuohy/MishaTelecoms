using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure.Data;
using MishaTelecoms.Infrastructure.Persistence.Dao;
using MishaTelecoms.Infrastructure.Persistence.Repositories;
using System;

namespace MishaTelecoms.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            /// Repository
            /// 
            services.AddScoped<ICDRRepository, CDRRepository>();
<<<<<<< HEAD
            /// Dao
            /// 
            services.AddScoped<ICDRDao, CDRDao>();
=======
            services.AddScoped<ICDRDao, CDRDao>();
            services.AddTransient<DbConnectionConfig>();

>>>>>>> 0e4c3d8e3361532a4d5afb82a3343d6c040f99a7
            /// Helpers
            /// 
            services.AddScoped<ISqlHelper, SqlHelper>();
            services.AddScoped<ISqlHelperAsync, SqlHelperAsync>();
            services.AddScoped<ITransaction, Transaction>();

            return services;
        }
    }
}