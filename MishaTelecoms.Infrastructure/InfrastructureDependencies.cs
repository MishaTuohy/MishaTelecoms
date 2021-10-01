using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Application.Interfaces.Dao;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Interfaces.Repositories.Users;
using MishaTelecoms.Infrastructure.Data;
using MishaTelecoms.Infrastructure.Persistence.Dao;
using MishaTelecoms.Infrastructure.Persistence.Repositories;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace MishaTelecoms.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            /// Repository
            services.AddTransient<ICDRRepository, CDRRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            /// Dao
            services.AddTransient<ICDRDao, CDRDao>();
            services.AddTransient<IUserDao, UserDao>();

            /// Helpers
            services.AddTransient<ISqlHelperAsync, SqlHelperAsync>();
            services.AddTransient<ITransaction, Transaction>();

            // ** Register this once at startup
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

            return services;
        }
    }
}