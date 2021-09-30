using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Infrastructure;
using System;
using MishaTelecoms.API.Dependencies.ConfigDependencies;
using MishaTelecoms.Application;

namespace MishaTelecoms.API.Dependencies
{
    public static class APIDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            services.AddApplication(configuration);

            // Assign your config so you can reuse it in Data layer
            services.AddDbConnectionConfiguration(configuration);

            // Authorized Application Details

            // Jwt Authentication set up
            // services.AddJwtDependencies(configuration);

            services.AddSwaggerDependency();
            // Hook up infrastructure dependancies
            services.AddInfrastructure(configuration);


            return services;
        }
    }
}
