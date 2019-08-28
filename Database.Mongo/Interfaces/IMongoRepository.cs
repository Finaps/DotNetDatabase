using System;
using System.Threading.Tasks;
using Database.Core.Abstractions;

namespace Database.Mongo.Interfaces
{
  public interface IMongoRepository<T> : IAsyncRepository<T>
  {
    Task UpdateAsync(T entity);
    Task RemoveAsync(Guid id);
  }
}