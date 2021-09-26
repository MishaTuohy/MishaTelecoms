using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services.CDRImporter
{
    public interface ICDRImporter
    {
        Task SendToDB(List<CDRDataDto> entity);
    }
}
