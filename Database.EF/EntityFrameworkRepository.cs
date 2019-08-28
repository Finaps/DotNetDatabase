using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.EF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.EF
{
  public class EntityFrameworkRepository<T> : IEntityFrameworkRepository<T> where T : class
  {
    protected readonly DbContext Context;
    public EntityFrameworkRepository(DbContext context)
    {
      Context = context;
    }
    public virtual void Add(T entity)
    {
      Context.Set<T>().Add(entity);
    }

    public virtual Task AddAsync(T entity)
    {
      return Context.Set<T>().AddAsync(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
      Context.Set<T>().AddRange(entities);
    }

    public virtual Task AddRangeAsync(IEnumerable<T> entities)
    {
      return Context.Set<T>().AddRangeAsync(entities);
    }

    public virtual T Get(Guid id)
    {
      return Context.Set<T>().Find(id);
    }

    public virtual Task<T> GetAsync(Guid id)
    {
      return Context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
      Context.Set<T>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<T> entities)
    {
      Context.Set<T>().RemoveRange(entities);
    }
  }
}