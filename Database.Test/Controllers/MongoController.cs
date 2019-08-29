using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Test.Models;
using Database.Test.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Database.Test.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class MongoController : ControllerBase
  {
    private readonly ITestMongoRepository _testMongoRepository;
    public MongoController(ITestMongoRepository testMongoRepository)
    {
      _testMongoRepository = testMongoRepository;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<List<TestMongoObject>>> Get()
    {
      return await _testMongoRepository.GetAsync(10, 0);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TestMongoObject>> Get(Guid id)
    {
      return await _testMongoRepository.GetByIdAsync(id);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<TestMongoObject>> Post(TestMongoObject value)
    {
      await _testMongoRepository.AddAsync(value);
      return value;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
