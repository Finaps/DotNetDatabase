using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Mongo;
using Database.Test.Models;
using MongoDB.Driver;

namespace Database.Test.Repositories
{
  public class TestMongoRepository : MongoRepository<TestMongoObject>
  {
    public TestMongoRepository(IMongoCollection<TestMongoObject> collection) : base(collection)
    {
    }
  }
}