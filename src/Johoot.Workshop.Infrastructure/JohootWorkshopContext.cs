using Johoot.Data;
using Microsoft.EntityFrameworkCore;

namespace Johoot.Workshop.Infrastructure
{
  public class JohootWorkshopContext : DbContext
  {
    public JohootWorkshopContext(DbContextOptions<JohootWorkshopContext> options) : base(options)
    {
    }

    public DbSet<Quize> Quizes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
