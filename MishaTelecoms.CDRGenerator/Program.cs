using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MishaTelecoms.Application.Interfaces.Services.CDRGenerator;
using MishaTelecoms.Application.Interfaces.Services.CDRImporter;
using MishaTelecoms.CDRGenerator.Generators;
using MishaTelecoms.CDRGenerator.Importer;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure;
using System;
using System.IO;

namespace MishaTelecoms.CDRGenerator
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
                   true)
               .AddCommandLine(args)
               .AddEnvironmentVariables()
               .Build();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<ICDRGenerator, CDRDataGenerator>();
                    services.AddTransient<ICDRImporter, DbImporter>();
                    IConfiguration configuration = hostContext.Configuration;
                    var CDRGeneratorConfig = new CDRGeneratorConfig();
                    configuration.GetSection("CDRDataConfig").Bind(CDRGeneratorConfig);
                    services.AddSingleton(CDRGeneratorConfig);

                    var dbConnectionConfig = new DbConnectionConfig();
                    configuration.GetSection("DbConnectionConfig").Bind(dbConnectionConfig);
                    services.AddSingleton(dbConnectionConfig);

                    services.AddAutoMapper(typeof(Worker));

                    services.AddInfrastructure(configuration);
                });
    }
}
