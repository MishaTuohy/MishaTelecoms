using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Interfaces.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface ICDRRepository : IRepository<CDRDataDto>
    {
        Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(ITransaction _trans, string Country, string CallType, int Duration);
    }
}
