using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Core.Models;
using Database.Mongo.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Database.Mongo.Pagination
{
  public static class IQueryablePaginationExtensions
  {
    public static async Task<PaginatedResponse<T>> AsPaginatedResponse<T>(this IMongoQueryable<T> workflows, int limit, int offset) where T : class, IMongoModel
    {
      var dataTask = limit > 0 ? workflows.Skip(offset).Take(limit).ToListAsync() : Task.FromResult(new List<T>());
      var countTask = workflows.CountAsync();

      await Task.WhenAll(dataTask, countTask);

      var data = await dataTask;
      var count = await countTask;

      return PaginatedResponse<T>.Create(data, limit, offset, count);
    }
  }
}