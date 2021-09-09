using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Infrastructure;
using MishaTelecoms.Domain.Settings;
using System;
using System.IO;
using System.Reflection;

namespace MishaTelecoms.API
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

            // Hook up infrastructure dependancies
            services.AddInfrastructure(configuration);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                        Version = "v1"
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }
}
