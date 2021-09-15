using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services.CDRData
{
    public interface ICDRService
    {
        Task<bool> AddAsync(CDRDataDto Entity);
        Task<CDRDataDto> GetByIdAsync(Guid Id);
        Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(string Country, string CallType, int Duration);
        Task<IReadOnlyList<CDRDataDto>> GetAllAsync();
        Task<bool> DeleteAsync(Guid Id);
        Task<IReadOnlyList<CDRDataDto>> GetByCountryAsync(string Country);
        Task<IReadOnlyList<CDRDataDto>> GetByCallTypeAsync(string CallType);
    }
}
