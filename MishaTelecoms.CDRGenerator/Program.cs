using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Services.CDRGenerator;
using MishaTelecoms.Application.Interfaces.Services.CDRImporter;
using MishaTelecoms.CDRGenerator.Generators;
using MishaTelecoms.CDRGenerator.Importer;
using MishaTelecoms.CDRGenerator.Models;
using MishaTelecoms.Domain.Settings;

namespace MishaTelecoms.CDRGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    IConfiguration configuration = hostContext.Configuration;
                    var CDRGeneratorConfig = new CDRGeneratorConfig();
                    configuration.GetSection("CDRGeneratorConfig").Bind(CDRGeneratorConfig);
                    services.AddSingleton(CDRGeneratorConfig);
                    services.AddTransient<ICDRGenerator<CDRDataModel>, CDRDataGenerator>();
                    services.AddTransient<ICDRImporter<CDRDataDto>, DbImporter>();
                });
    }
}
