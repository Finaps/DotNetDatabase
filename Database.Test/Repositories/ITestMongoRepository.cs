using Database.Mongo.Interfaces;
using Database.Test.Models;

namespace Database.Test.Repositories
{
  public interface ITestMongoRepository : IMongoRepository<TestMongoObject>
  {

  }
}