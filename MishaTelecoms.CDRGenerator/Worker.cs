using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Services.CDRGenerator;
using MishaTelecoms.Application.Interfaces.Services.CDRImporter;
using MishaTelecoms.CDRGenerator.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.CDRGenerator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICDRImporter<CDRDataDto> _importer;
        private readonly ICDRGenerator<CDRDataModel> _dataGenerator;
        private readonly IMapper _mapper;

        public Worker(ILogger<Worker> logger, ICDRGenerator<CDRDataModel> dataGenerator, ICDRImporter<CDRDataDto> importer,
            IMapper mapper)
        {
            _logger = logger;
            _dataGenerator = dataGenerator;
            _importer = importer;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                List<CDRDataDto> CDRDataList = new List<CDRDataDto>();
                try
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var data = _mapper.Map<CDRDataModel, CDRDataDto>(_dataGenerator.GetCDRData());
                        CDRDataList.Add(data);
                    }

                    await _importer.SendToDB(CDRDataList);
                    _logger.LogInformation("Generated new CDR Data at: {time}", DateTimeOffset.Now);
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