using System;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.CDRGenerator.Models;
using MishaTelecoms.Infrastructure.Utils;
using MishaTelecoms.Application.Interfaces.Services.CDRGenerator;

namespace MishaTelecoms.CDRGenerator.Generators
{
    public class CDRDataGenerator : CDRGeneratorUtils, ICDRGenerator<CDRDataModel>
    {
        private readonly ILogger<CDRDataGenerator> _logger;

        public CDRDataGenerator(ILogger<CDRDataGenerator> logger, CDRGeneratorConfig config) : base(config)
        {
            _logger = logger;
        }

        public CDRDataModel GetCDRData()
        {
            try
            {
                CDRDataModel cdr = new CDRDataModel
                {
                    Id = Guid.NewGuid(),
                    CallingNumber = GeneratePhoneNumber(),
                    CalledNumber = GeneratePhoneNumber(),
                    Country = GenerateCountry(),
                    CallType = GenerateCallType(),
                    Duration = GenerateDuration(),
                    DateCreated = GenerateDate(),
                };
                cdr.Cost = cdr.CalculateCost(cdr.Country, cdr.Duration);
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
