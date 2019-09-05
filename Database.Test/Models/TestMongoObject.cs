using System;
using Database.Mongo.Interfaces;

namespace Database.Test.Models
{
  public class TestMongoObject : IMongoModel
  {
    public string CoolString { get; set; }
    public Guid Id { get; set; }
  }
}