using System;
using System.Threading.Tasks;
using Database.Core.Abstractions;

namespace Database.Mongo.Interfaces
{
  public interface IMongoRepository<T> : IRepository<T> where T : class, IMongoModel
  {
    Task UpdateAsync(T entity);
    Task RemoveAsync(Guid id);
    Task RemoveAsync(T entity);
  }
}