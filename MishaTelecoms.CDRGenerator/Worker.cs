using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.CDRGenerator.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.CDRGenerator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICDRGenerator _dataGenerator;
        private readonly ICDRFileGenerator _fileGenerator;

        public Worker(ILogger<Worker> logger, ICDRGenerator dataGenerator, ICDRFileGenerator fileGenerator)
        {
            _logger = logger;
            _dataGenerator = dataGenerator;
            _fileGenerator = fileGenerator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        CDRDataDto data = _dataGenerator.GetCDRData();
                        await _fileGenerator.AppendData(data.ToString());
                    }
                    _logger.LogInformation("Generated new csv file at: {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                await Task.Delay(600000, stoppingToken);
            }
        }
    }
}