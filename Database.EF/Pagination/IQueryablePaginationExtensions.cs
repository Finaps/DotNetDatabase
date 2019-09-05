using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.EF.Pagination
{
  public static class IQueryablePaginationExtensions
  {
    public static async Task<PaginatedResponse<T>> AsPaginatedResponse<T>(this IQueryable<T> workflows, int limit, int offset) where T : class
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