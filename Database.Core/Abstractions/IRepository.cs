using System;
using System.Collections.Generic;

namespace Database.Core.Abstractions
{
  public interface IRepository<T>
  {
    void Add(T entity);
    void Remove(T entity);
    T GetById(Guid id);
    IEnumerable<T> Get(int limit, int offset);

  }
}