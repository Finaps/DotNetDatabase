using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.EF;
using Database.Test.Models;
using Database.Test.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Database.Test.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class EfController : ControllerBase
  {
    private readonly ITestEfRepository _testEfRepository;
    public EfController(ITestEfRepository testEfRepository)
    {
      _testEfRepository = testEfRepository;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<List<TestEfObject>>> Get()
    {
      return await _testEfRepository.GetAsync(10, 0);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TestEfObject>> Get(Guid id)
    {
      return await _testEfRepository.GetByIdAsync(id);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<TestEfObject>> Post(TestEfObject value)
    {
      await _testEfRepository.AddAsync(value);
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
