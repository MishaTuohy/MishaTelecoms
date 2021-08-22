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
        Task<bool> AddAsync(ITransaction _trans, T entity);
        Task<bool> UpdateAsync(ITransaction trans, T entity);
        Task<bool> DeleteAsync(ITransaction _trans, T entity);
    }
}