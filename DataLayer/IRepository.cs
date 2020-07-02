using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRepository<T>
         where T : class
    {
        Task<T> Read(int id);
        Task<IQueryable<T>> ReadAll();
        Task<T> Create(T model);
        Task<T> Delete(int id);
        Task<T> Update(T model);
    }
}
