using System;
using Database.Mongo.Interfaces;
using MongoDB.Driver;

namespace Database.Mongo.Extentions
{
  public static class MongoCoreExtensions
  {
    public static FilterDefinition<T> IdFilter<T>(T obj) where T : IMongoModel
    {
      return Builders<T>.Filter.Eq(x => x.Id, obj.Id);
    }

    public static FilterDefinition<T> IdFilter<T>(Guid id) where T : IMongoModel
    {
      return Builders<T>.Filter.Eq(x => x.Id, id);
    }

  }
}