using Database.EF.Interfaces;
using Database.Test.Models;

namespace Database.Test.Repositories
{
  public interface ITestEfRepository : IEntityFrameworkRepository<TestEfObject>
  {

  }
}