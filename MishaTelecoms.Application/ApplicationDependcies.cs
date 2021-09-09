using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MishaTelecoms.Application
{
    public static class ApplicationDependcies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            return services;
        }
    }
}