using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Services
{
    public interface ICDRGenerator<T> where T : class
    {
        T GetCDRData();
        string GenerateCallNumber();
        string GenerateCountry();
        string GenerateCallType();
        int GenerateDuration();
        string GenerateDateCreated();
    }
}
