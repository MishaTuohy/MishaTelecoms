using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Services.CDRGenerator
{
    public interface ICDRGenerator<T> where T : class
    {
        T GetCDRData();
    }
}
