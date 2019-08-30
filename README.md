# Database Abstraction

The purpose of this package is to provide a basis of a repository pattern on top of a given database.
Currently this package targets Mongo and Entity Framework.

## Setup

### Mongo

Create a mongo model:

```csharp
  public class TestMongoObject : IMongoModel
  {
    public string CoolString { get; set; }
    public Guid Id { get; set; }
  }
```

The IMongoModel requires that you have an Id configured for you object.

Create a interface for your repository (optional):

```csharp 
  public interface ITestMongoRepository : IMongoRepository<TestMongoObject>
  {

  }
```

Create your repository:


```csharp 
  public class TestMongoRepository : MongoRepository<TestMongoObject>, ITestMongoRepository
  {
    public TestMongoRepository(IMongoCollection<TestMongoObject> collection) : base(collection)
    {
    }
  }
```

### Entity Framework

Create a model:

```csharp
  public class TestEfObject
  {
    public Guid Id { get; set; }
    public string CoolString { get; set; }
  }
```

Create a interface for your repository (optional):

```csharp 
  public interface ITestEfRepository : IEntityFrameworkRepository<TestEfObject>
  {

  }
```

Create your repository:


```csharp 
  public class TestEfRepository : EntityFrameworkRepository<TestEfObject>, ITestEfRepository
  {
    public TestEfRepository(TestDbContext context) : base(context)
    {
    }
  }
```

## Startup

Configure Mongo / DB Context as you would usually to ensure the dependency injection works correctly.

