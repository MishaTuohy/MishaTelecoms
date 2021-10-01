using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories.CDRData
{
    public interface ICDRRepository : IRepository<CDRDataDto>
    {
        Task<IReadOnlyList<CDRDataDto>> GetByCountryAsync(string country);
        Task<IReadOnlyList<CDRDataDto>> GetByCallTypeAsync(string callType);
        Task<IReadOnlyList<CDRDataDto>> GetByDateCreatedAsync(string dateCreated);
        Task<bool> UpdateCallingNumberAsync(Guid Id, string CallingNumber);
        Task<bool> UpdateCalledNumberAsync(Guid Id, string CalledNumber);
        Task<bool> UpdateCountryAsync(Guid Id, string Country);
        Task<bool> UpdateCallTypeAsync(Guid Id, string CallType);
        Task<bool> UpdateDurationAsync(Guid Id, int Duration);
        Task<bool> UpdateCostAsync(Guid Id, double Cost);
    }
}
