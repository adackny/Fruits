using Fruits.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fruits.Infrastructure.Contexts;

public class FruitsDbContext(DbContextOptions<FruitsDbContext> options) : DbContext(options)
{
    public DbSet<FruitEntity> Fruits { get; set; }
    public DbSet<SellerEntity> Sellers { get; set; }
    public DbSet<SellerFruitEntity> SellerFruits { get; set; }
}
