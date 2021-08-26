using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Application.Interfaces.Data;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Infrastructure.Data;
using MishaTelecoms.Infrastructure.Persistence.Repositories;

namespace MishaTelecoms.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            /// Repository
            /// 
            services.AddScoped<ICDRRepository, CDRRepository>();

            /// Helpers
            /// 
            services.AddScoped<ISqlHelper, SqlHelper>();
            services.AddScoped<ISqlHelperAsync, SqlHelperAsync>();
            services.AddScoped<ITransaction, Transaction>();

            return services;
        }
    }
}
