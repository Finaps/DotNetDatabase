using System.Collections.Generic;
using Database.Mongo.Interfaces;
using MongoDB.Driver;

namespace InvoiceRepository.FunctionalTests.Data
{
  public static class MongoSeeder
  {
    public static void SeedData<T>(string db, string connectionString, List<T> dataToSeed) where T : IMongoModel
    {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(db);

      database.GetCollection<T>(typeof(T).Name).InsertMany(dataToSeed);
    }

    public static void WipeDb<T>(string db, string connectionString) where T : IMongoModel
    {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(db);

      database.DropCollection(typeof(T).Name);
    }
  }
}
