using Microsoft.Extensions.Logging;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services
{
    public class CDRService : ICDRService
    {
        private readonly ILogger<CDRService> _logger;
        private readonly ICDRRepository _repository;

        public CDRService(
            ILogger<CDRService> logger,
            ICDRRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<bool> AddAsync(CDRDataDto entity)
        {
            bool result;

            if (entity == null)
                throw new ArgumentNullException("CDR Data cannot be null");

            using (Transaction _trans = new Transaction())
            {
                try
                {
                    result = await _repository.AddAsync(_trans, entity);

                    if (result)
                    {
                        _trans.Commit();
                    }
                }
                catch (Exception ex)
                {
                    _trans.Rollback();
                    _logger.LogError(ex.Message);
                    throw;
                }
            }

            return result;
        }
    }
}
