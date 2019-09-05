using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Core.Models;

namespace Database.Core.Abstractions
{
  public interface IRepository<T> where T : class
  {
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<List<T>> GetAsync(int limit, int offset);
    Task<PaginatedResponse<T>> GetAsyncAsPaginatedResponse(int limit, int offset);
    Task<T> GetByIdAsync(Guid id);
    Task<long> CountAsync();
  }
}