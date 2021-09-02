using System;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Application.Interfaces.Services;

namespace MishaTelecoms.CDRGenerator.Generators
{
    public class FileGenerator : ICDRFileGenerator
    {
        private readonly ILogger<FileGenerator> _logger;
        private readonly string _filepath;

        public FileGenerator(ILogger<FileGenerator> logger, CDRGeneratorConfig config)
        {
            _logger = logger;
            _filepath = config.Filepath;
        }

        public async Task AppendData(string data)
        {
            if (data == null)
                throw new ArgumentNullException("Can not be null");
            try
            {
                await File.AppendAllTextAsync($"{_filepath}{DateTime.Now.ToString("yyyyMMdd")}.csv", data + Environment.NewLine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}