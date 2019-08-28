using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Database.Mongo.Interfaces
{
  public interface IMongoModel
  {
    [BsonId]
    Guid Id { get; set; }
  }
}