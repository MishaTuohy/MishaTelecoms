using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface ICDRRepository : IRepository<CDRDataDto>
    {
        Task<IEnumerable<CDRDataDto>> GetFilteredCDRDataAsync(string Country, string CallType, int Duration);
    }
}
