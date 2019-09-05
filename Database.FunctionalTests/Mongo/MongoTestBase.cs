using System;
using System.IO;
using System.Reflection;
using Database.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Database.FunctionalTests.Mongo
{
  public class MongoTestBase
  {
    private static readonly string baseUrl = "mongo";
    public TestServer CreateServer()
    {
      var path = Assembly.GetAssembly(typeof(MongoTestBase))
        .Location;

      var hostBuilder = new WebHostBuilder()
          .UseContentRoot(Path.GetDirectoryName(path))
          .UseStartup<Startup>();

      var testServer = new TestServer(hostBuilder);
      return testServer;
    }
    public static class Get
    {
      public static string TestData()
      {
        return baseUrl;
      }

      public static string TestDataById(Guid id)
      {
        return $"{baseUrl}/{id}";
      }

      public static string InvoicesByQuery(
        Guid batchId,
        Guid debtCollectionAgencyId)
      {
        return $"invoice?batchId={batchId}&debtCollectionAgencyId={debtCollectionAgencyId}";
      }

    }

    public static class Delete
    {
      public static string TestDataById(Guid id)
      {
        return $"{baseUrl}/{id}";
      }
    }

    public static class Post
    {
      public static string CreateTestData()
      {
        return baseUrl;
      }
    }

    public static class Put
    {
      public static string UpdateTestData(Guid id)
      {
        return $"{baseUrl}/{id}";
      }
    }


  }
}