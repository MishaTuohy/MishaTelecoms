using MishaTelecoms.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface ICDRRepository : IRepository<CDRDataDto>
    {
        Task<IReadOnlyList<CDRDataDto>> GetByCountryCallTypeDurationAsync(string Country, string CallType, int Duration);
        Task<IReadOnlyList<CDRDataDto>> GetByCountryAsync(string country);
        Task<IReadOnlyList<CDRDataDto>> GetByCallTypeAsync(string callType);
    }
}
