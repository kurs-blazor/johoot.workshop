

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Johoot.Workshop.Infrastructure
{
  public class JohootWorkshopContextFactory : IDesignTimeDbContextFactory<JohootWorkshopContext>
  {
    private const string ConnectionStringName = "DefaultDbConnection";
    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

    public JohootWorkshopContext CreateDbContext(string[] args)
    {
      return Create(
       Directory.GetCurrentDirectory(),
       Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
    }

    protected JohootWorkshopContext CreateNewInstance(DbContextOptions<JohootWorkshopContext> options)
    {
      return new JohootWorkshopContext(options);
    }

    private JohootWorkshopContext Create(string basePath, string environmentName)
    {
      var configuration = new ConfigurationBuilder()
       .SetBasePath(basePath)
       .AddJsonFile("appsettings.json")
       .AddJsonFile($"appsettings.Local.json", optional: true)
       .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
       .AddEnvironmentVariables()
       .Build();

      var connectionString = configuration.GetConnectionString(ConnectionStringName);

      return Create(connectionString);
    }

    private JohootWorkshopContext Create(string connectionString)
    {
      if (string.IsNullOrEmpty(connectionString))
      {
        throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
      }

      Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

      var optionsBuilder = new DbContextOptionsBuilder<JohootWorkshopContext>();

      optionsBuilder.UseSqlServer(connectionString);

      return CreateNewInstance(optionsBuilder.Options);
    }
  }


}

