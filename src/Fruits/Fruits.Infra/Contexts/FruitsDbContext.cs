using Fruits.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruits.Infra.Contexts;

public class FruitsDbContext : DbContext
{
    public FruitsDbContext(DbContextOptions<FruitsDbContext> options) : base(options) { }

    public DbSet<Fruit> Fruits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
