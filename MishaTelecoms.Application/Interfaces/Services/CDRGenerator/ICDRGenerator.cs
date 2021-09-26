using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.Application.Interfaces.Services.CDRGenerator
{
    public interface ICDRGenerator
    {
        CDRDataDto GetCDRData();
    }
}
