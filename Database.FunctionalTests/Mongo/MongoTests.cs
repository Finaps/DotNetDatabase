using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Database.Test.Models;
using InvoiceRepository.FunctionalTests.Data;
using Newtonsoft.Json;
using Xunit;

namespace Database.FunctionalTests.Mongo
{
  public class MongoTests : MongoTestBase, IDisposable
  {
    public MongoTests()
    {
      var data = new List<TestMongoObject>()
      {
          new TestMongoObject()
          {
            Id = Guid.Parse("164661d5-aeff-445a-8d35-5815ba7d92bb"),
            CoolString = "thats pretty cool"
          }
        };

      MongoSeeder.SeedData("MongoTest", "mongodb://localhost:27017/MongoTest", data);
    }

    [Fact]
    public async Task GetById()
    {
      var idToFind = Guid.Parse("164661d5-aeff-445a-8d35-5815ba7d92bb");
      using (var server = CreateServer())
      {
        var response = await server.CreateClient()
        .GetAsync(Get.TestDataById(idToFind));

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TestMongoObject>(jsonString);
        Assert.Equal(idToFind, result.Id);
      }
    }

    [Fact]
    public async Task GetAll()
    {
      using (var server = CreateServer())
      {
        var response = await server.CreateClient()
        .GetAsync(Get.TestData());

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<TestMongoObject>>(jsonString);
        Assert.NotEmpty(result);
      }
    }

    [Fact]
    public async Task DeleteTestData()
    {
      var idToFind = Guid.Parse("164661d5-aeff-445a-8d35-5815ba7d92bb");
      using (var server = CreateServer())
      {
        var response = await server.CreateClient()
        .DeleteAsync(Delete.TestDataById(idToFind));

        response.EnsureSuccessStatusCode();
      }
    }

    [Fact]
    public async Task CreateTest()
    {
      var toCreate = new TestMongoObject()
      {
        CoolString = "nice"
      };

      var json = JsonConvert.SerializeObject(toCreate);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

      using (var server = CreateServer())
      {
        var response = await server.CreateClient()
        .PostAsync(Post.CreateTestData(), stringContent);

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TestMongoObject>(jsonString);

        Assert.NotEqual(Guid.Empty, result.Id);
      }
    }

    [Fact]
    public async Task UpdateTest()
    {
      var idToUpdate = Guid.Parse("164661d5-aeff-445a-8d35-5815ba7d92bb");
      var newString = "nice";
      var ToUpdate = new TestMongoObject()
      {
        Id = idToUpdate,
        CoolString = newString
      };

      var json = JsonConvert.SerializeObject(ToUpdate);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

      using (var server = CreateServer())
      {
        var putResponse = await server.CreateClient()
        .PutAsync(Put.UpdateTestData(idToUpdate), stringContent);

        putResponse.EnsureSuccessStatusCode();

        var getResponse = await server.CreateClient()
        .GetAsync(Get.TestDataById(idToUpdate));

        var jsonString = await getResponse.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TestMongoObject>(jsonString);

        Assert.Equal(newString, result.CoolString);
      }
    }




    public void Dispose()
    {
      MongoSeeder.WipeDb<TestMongoObject>("MongoTest", "mongodb://localhost:27017/MongoTest");
    }
  }
}
