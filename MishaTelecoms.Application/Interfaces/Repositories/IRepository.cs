using MishaTelecoms.Application.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> AddAsync(ITransaction _trans, T entity);
        Task UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
