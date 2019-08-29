using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Core.Exceptions;
using Database.Mongo.Extentions;
using Database.Mongo.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Database.Mongo
{
  public class MongoRepository<T> : IMongoRepository<T> where T : IMongoModel
  {
    protected readonly IMongoQueryable<T> _queryable;
    protected readonly IMongoCollection<T> _collection;
    public MongoRepository(
        IMongoCollection<T> collection
    )
    {
      _collection = collection;
      _queryable = collection.AsQueryable();
    }

    public virtual Task AddAsync(T entity)
    {
      return _collection.InsertOneAsync(entity);
    }

    public virtual Task<long> CountAsync()
    {
      return _collection.CountDocumentsAsync(Builders<T>.Filter.Empty);
    }

    public virtual Task<List<T>> GetAsync(int limit, int offset)
    {
      return _queryable.Skip(offset).Take(limit).ToListAsync();
    }

    public virtual Task<T> GetByIdAsync(Guid id)
    {
      return _queryable.SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public virtual Task RemoveAsync(T entity)
    {
      return _collection.DeleteOneAsync(mongoModel => mongoModel.Id == entity.Id);
    }
    public virtual Task RemoveAsync(Guid id)
    {
      return _collection.DeleteOneAsync(mongoModel => mongoModel.Id == id);
    }

    public virtual async Task UpdateAsync(T entity)
    {
      var filterById = MongoCoreExtensions.IdFilter(entity);
      var result = await _collection.FindOneAndReplaceAsync(filterById, entity);
      throw new EntityNotFoundException();
    }
  }
}