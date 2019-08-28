using System;
using System.Threading.Tasks;

namespace Database.Core.Abstractions
{
  public interface IAsyncRepository<T>
  {
    Task AddAsync(T entity);
    Task<T> GetAsync(Guid id);
  }
}