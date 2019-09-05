using Database.Test.Models;
using Database.Test.Repositories;
using Finaps.Commons.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Database.Test
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      //services.Configure<MongoOptions>(Configuration.GetSection("Mongo"));
      services.AddMongoDBConnection(new MongoOptions()
      {
        ConnectionString = "mongodb://localhost:27017/MongoTest",
        Database = "MongoTest"
      });
      services.UseMongoDBCollection<TestMongoObject>();
      services.AddScoped<ITestMongoRepository, TestMongoRepository>();
      services.AddScoped<ITestEfRepository, TestEfRepository>();
      // services.AddDbContext<TestDbContext>(options => options.UseInMemoryDatabase("coolkids"));
      services.AddDbContext<TestDbContext>(options => options.UseSqlite("Data source=cool.db"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
