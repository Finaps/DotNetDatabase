using Database.EF;
using Database.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Test.Repositories
{
  public class TestEfRepository : EntityFrameworkRepository<TestEfObject>, ITestEfRepository
  {
    public TestEfRepository(TestDbContext context) : base(context)
    {
    }
  }
}