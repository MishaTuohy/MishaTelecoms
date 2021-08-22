using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services
{
    public interface ICDRFileGeneratorService
    {
        Task AppendData(string data);
    }
}
