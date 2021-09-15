using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services.CDRImporter
{
    public interface ICDRImporter<T> where T : class
    {
        Task SendToDB(List<T> entity);
    }
}
