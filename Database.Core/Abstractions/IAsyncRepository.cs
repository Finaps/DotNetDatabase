using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Core.Abstractions
{
  public interface IAsyncRepository<T>
  {
    Task AddAsync(T entity);
    Task<List<T>> GetAsync(int limit, int offset);
    Task<T> GetByIdAsync(Guid id);
  }
}