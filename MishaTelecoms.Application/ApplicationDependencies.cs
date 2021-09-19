using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishaTelecoms.Application.Behaviours;
using System;

namespace MishaTelecoms.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}