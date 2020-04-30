using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Johoot.Workshop
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.ConfigureKestrel((option) =>
          {
            option.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
            option.AllowSynchronousIO = true;
            option.Limits.MaxConcurrentConnections = 100;
          });
          webBuilder.UseStartup<Startup>();
        });
  }
}
