using Johoot.Workshop.Infrastructure;
using Johoot.Workshop.Infrastructure.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Globalization;
using Newtonsoft.Json;

namespace Johoot.Workshop.Api
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
      services.AddControllers()
        .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
          new OpenApiInfo { Title = "Johoot.Workshop", Version = "v1" });
      });

      services.AddDbContext<JohootWorkshopContext>(cfg =>
      {
        cfg.UseSqlServer(Configuration.GetConnectionString("DefaultDbConnection"));
      });

      services.AddScoped<IQuestionRepository, QuestionRepository>();
      services.AddScoped<IQuizesRepository, QuizesRepository>();
      services.AddScoped<IAnswerRepository, AnswerRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger();
      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Johoot.Workshop API V1");
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
