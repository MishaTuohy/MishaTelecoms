using MishaTelecoms.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories.CDRData
{
    public interface ICDRRepository : IRepository<CDRDataDto>
    {
        Task<IReadOnlyList<CDRDataDto>> GetByCountryAsync(string country);
        Task<IReadOnlyList<CDRDataDto>> GetByCallTypeAsync(string callType);
    }
}
