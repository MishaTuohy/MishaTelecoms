using System;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Domain.Settings;
using System.Collections.Generic;
using System.Linq;
using MishaTelecoms.CDRGenerator.Models;
using MishaTelecoms.Application.Dtos;
using AutoMapper;

namespace MishaTelecoms.CDRGenerator.Generators
{
    public class DataGenerator : ICDRGenerator
    {
        private readonly ILogger<DataGenerator> _logger;
        private readonly List<string> _countries;
        private readonly List<string> _callTypes;
        private readonly IMapper _mapper;
        private readonly Random rnd = new Random();

        public DataGenerator(ILogger<DataGenerator> logger, CDRGeneratorConfig config,
            IMapper mapper)
        {
            _logger = logger;
            _countries = config.Countries;
            _callTypes = config.CallType;
            _mapper = mapper;
        }

        public CDRDataDto GetCDRData()
        {
            CDRDataModel cdr = new CDRDataModel();

            try
            {
                cdr.Id = Guid.NewGuid();
                cdr.CallingNumber = GenerateCallNumber();
                cdr.CalledNumber = GenerateCallNumber();
                cdr.Country = GenerateCountry();
                cdr.CallType = GenerateCallType();
                cdr.Duration = GenerateDuration();
                cdr.DateCreated = GenerateDateCreated();
                cdr.Cost = cdr.calculateCost(cdr.Country, cdr.Duration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            CDRDataDto data = _mapper.Map<CDRDataModel, CDRDataDto>(cdr);
            return data;
        }

        public string GenerateCallNumber()
        {
            string num = "";
            for (int i = 0; i < 10; i++)
                num += rnd.Next(0, 9).ToString();
            return num;
        }

        public string GenerateCountry()
        {
            string result;
            try
            {
                result = _countries[rnd.Next(0, _countries.Count())];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return result;
        }

        public string GenerateCallType()
        {
            string result;
            try
            {
                result = _callTypes[rnd.Next(0, _callTypes.Count())];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return result;
        }

        public int GenerateDuration()
        {
            return rnd.Next(1, 30);
        }

        public string GenerateDateCreated()
        {
            return DateTimeOffset.Now.ToString("yyyyMMdd");
        }
    }
}
