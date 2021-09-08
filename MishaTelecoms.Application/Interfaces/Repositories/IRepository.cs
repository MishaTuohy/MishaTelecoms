using MishaTelecoms.Application.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid Id);
    }
}