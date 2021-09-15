using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Services.CDRImporter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.CDRGenerator.Importer
{
    public class DbImporter : ICDRImporter<CDRDataDto>
    {
        private readonly ILogger<DbImporter> _logger;

        public DbImporter(ILogger<DbImporter> logger)
        {
            _logger = logger;
        }

        public async Task SendToDB(List<CDRDataDto> CDRDataList)
        {
            if (CDRDataList.Count() <= 0)
                throw new ArgumentNullException("CDR Data cannot be null");
            try
            {
                foreach (var CDR in CDRDataList)
                    await PostCDRData(CDR);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task PostCDRData(CDRDataDto CDRData)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/api/cdrdata"))
            {
                var json = JsonConvert.SerializeObject(CDRData);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
        }
    }
}