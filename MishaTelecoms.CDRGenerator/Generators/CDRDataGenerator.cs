using System;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Application.Interfaces.Services.CDRGenerator;
using MishaTelecoms.Infrastructure.Utils.CDRData;
using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.CDRGenerator.Generators
{
    public class CDRDataGenerator : CDRGeneratorUtils, ICDRGenerator
    {
        private readonly ILogger<CDRDataGenerator> _logger;

        public CDRDataGenerator(ILogger<CDRDataGenerator> logger, CDRGeneratorConfig config) : base(config)
        {
            _logger = logger;
        }

        public CDRDataDto GetCDRData()
        {
            try
            {
                CDRDataDto cdr = new CDRDataDto
                {
                    Id = Guid.NewGuid(),
                    CallingNumber = GeneratePhoneNumber(),
                    CalledNumber = GeneratePhoneNumber(),
                    Country = GenerateCountry(),
                    CallType = GenerateCallType(),
                    DateCreated = DateTime.Now.ToString("yyyyMMdd"),
                    Duration = GenerateDuration(),
                };

                cdr.Cost = CalculateCost(cdr.Country, cdr.Duration);
                return cdr;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
