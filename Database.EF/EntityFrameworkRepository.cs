using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Database.Core.Abstractions;
using Database.Core.Models;
using Database.EF.Pagination;

namespace Database.EF
{
  public abstract class EntityFrameworkRepository<T> : IEntityFrameworkRepository<T> where T : class
  {
    protected readonly DbContext Context;
    public EntityFrameworkRepository(DbContext context)
    {
      Context = context;
    }
    public virtual Task AddAsync(T entity)
    {
      return Context.Set<T>().AddAsync(entity);
    }
    public virtual Task AddRangeAsync(IEnumerable<T> entities)
    {
      return Context.Set<T>().AddRangeAsync(entities);
    }
    public async virtual Task<long> CountAsync()
    {
      return await Context.Set<T>().CountAsync();
    }
    public virtual IEnumerable<T> Get(int limit, int offset)
    {
      return Context.Set<T>().Skip(offset).Take(limit).ToList();
    }
    public virtual Task<PaginatedResponse<T>> GetAsyncAsPaginatedResponse(int limit, int offset)
    {
      return Context.Set<T>().AsQueryable().AsPaginatedResponse(limit, offset);
    }
    public virtual Task<List<T>> GetAsync(int limit, int offset)
    {
      return Context.Set<T>().Skip(offset).Take(limit).ToListAsync();
    }
    public virtual Task<T> GetByIdAsync(Guid id)
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