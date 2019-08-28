using System;
namespace Database.Core.Abstractions
{
  public interface IRepository<T>
  {
    void Add(T entity);
    void Remove(T entity);
    T Get(Guid id);
  }
}