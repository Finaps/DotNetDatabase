using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Core.Abstractions;

namespace Database.EF.Interfaces
{
  public interface IEntityFrameworkRepository<T> : IRepository<T>, IAsyncRepository<T>
  {
    void AddRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities);
    void RemoveRange(IEnumerable<T> entities);
    Task<int> CountAsync();
    int Count();
  }
}