using System;
using System.Threading.Tasks;

namespace Database.Core.Abstractions
{
  public interface IAsyncRepository<T>
  {
    Task AddAsync(T entity);
    Task RemoveAsync(T entity);
    Task<T> GetAsync(Guid id);
  }
}