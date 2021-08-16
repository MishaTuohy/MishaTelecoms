using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Application.Interfaces.Repositories;
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

            return services;
        }
    }
}
