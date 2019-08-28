using System;
using System.Threading.Tasks;
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

    public virtual async Task AddAsync(T entity)
    {
      await _collection.InsertOneAsync(entity);
    }

    public virtual Task<T> GetAsync(Guid id)
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
      await _collection.FindOneAndReplaceAsync(filterById, entity);
    }
  }
}