using Microsoft.EntityFrameworkCore;

namespace Database.Test.Models
{
  public class TestDbContext : DbContext
  {
    public DbSet<TestEfObject> testEfObjects { get; set; }
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    { }
  }
}