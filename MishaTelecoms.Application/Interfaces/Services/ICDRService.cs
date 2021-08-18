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
    }
}
