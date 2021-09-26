using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories.CDRData;
using MishaTelecoms.Application.Interfaces.Services.CDRImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.CDRGenerator.Importer
{
    public class DbImporter : ICDRImporter
    {
        private readonly ILogger<DbImporter> _logger;
        private readonly ICDRRepository _repository;

        public DbImporter(ILogger<DbImporter> logger, ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task SendToDB(List<CDRDataDto> CDRDataList)
        {
            if (CDRDataList.Count() <= 0)
                throw new ArgumentNullException("CDR Data cannot be null");
            try
            {
                foreach (var CDR in CDRDataList)
                    await _repository.AddAsync(CDR);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}