using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerInfo.Repository.Contracts
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<List<T>> FindAll();
        Task<bool> Exists(T entity);
        Task<T> FindById(Guid id);
    }
}