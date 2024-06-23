using Fruits.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fruits.Infra;

public class FruitsContextFactory : IDesignTimeDbContextFactory<FruitsDbContext>
{
    public FruitsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FruitsDbContext>();
        optionsBuilder.UseSqlite("Data source=fruits.db");

        return new FruitsDbContext(optionsBuilder.Options);
    }
}
