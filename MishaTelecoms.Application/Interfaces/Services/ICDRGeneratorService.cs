using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Interfaces.Services
{
    public interface ICDRGeneratorService
    {
        CDRDataDto GetCDRData();
        string GenerateCallNumber();
        string GenerateCountry();
        string GenerateCallType();
        int GenerateDuration();
        string GenerateDateCreated();
    }
}
