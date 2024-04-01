namespace Persistence;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<BookEntity> Books { get; set; } = null!;

  public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}
