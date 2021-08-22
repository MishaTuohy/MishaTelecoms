using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.CDRGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.CDRGenerator.Importers
{
    public class DbImporter : ICDRImporter<CDRDataDto>
    {
        public Task SendToDB(CDRDataDto entity)
        {
            throw new NotImplementedException();
        }
    }
}