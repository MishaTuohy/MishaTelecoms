using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Create(T entity);
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task Update(T entity);
        Task Delete(T entity);
    }
}
