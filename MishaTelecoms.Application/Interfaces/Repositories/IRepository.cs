using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Get data entry by Id from database asynchronously
        Task<T> GetByIdAsync(Guid Id);
        // Get all data entries from database asynchronously
        Task<IReadOnlyList<T>> GetAllAsync();
        // Add a data entry in database asynchronously 
        Task<bool> AddAsync(T entity);
        // Update a data entry in database asynchronously
        Task<bool> UpdateAsync(T entity);
        // Delete a data entry in database asynchronously
        Task<bool> DeleteAsync(Guid Id);
    }
}