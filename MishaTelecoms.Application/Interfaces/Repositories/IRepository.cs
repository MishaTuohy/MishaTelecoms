using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Create(T entity);
        T GetById(Guid id);
        List<T> GetAll();
        T Update(T entity);
        void Delete(Guid id);
    }
}
