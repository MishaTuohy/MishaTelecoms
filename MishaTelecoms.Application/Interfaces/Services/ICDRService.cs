using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services
{
    public interface ICDRService
    {
        Task<bool> AddAsync(CDRDataDto entity);
        Task<CDRDataDto> GetByIdAsync(Guid Id);
        Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(string Country, string CallType, int Duration);
        Task<IReadOnlyList<CDRDataDto>> GetAllAsync();
        Task<bool> DeleteAsync(CDRDataDto entity);
    }
}
