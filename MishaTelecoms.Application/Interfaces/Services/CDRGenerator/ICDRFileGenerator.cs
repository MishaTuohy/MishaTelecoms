using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services.CDRGenerator
{
    public interface ICDRFileGenerator
    {
        Task AppendData(string data);
    }
}
