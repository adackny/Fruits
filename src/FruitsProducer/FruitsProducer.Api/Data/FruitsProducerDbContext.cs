using Microsoft.EntityFrameworkCore;

namespace FruitsProducer.Api;

public class FruitsProducerDbContext : DbContext
{
    public FruitsProducerDbContext(DbContextOptions<FruitsProducerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Fruit> Fruits { get; set; }

    public DbSet<ProducerCountry> ProducerCountries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProducerCountry>().HasData(
            new ProducerCountry
            {
                Id = 1,
                Name = "España"
            },
            new ProducerCountry
            {
                Id = 2,
                Name = "Cuba"
            },
            new ProducerCountry
            {
                Id = 3,
                Name = "EEUU",
            },
            new ProducerCountry
            {
                Id = 4,
                Name = "India"
            }
        );


        modelBuilder.Entity<Fruit>().HasData(
            new
            {
                Id = 1,
                Name = "Banana",
                Price = 3.99m,
                ProducerCountryId = 1 // España
            },
            new
            {
                Id = 2,
                Name = "Banana",
                Price = 2.99m,
                ProducerCountryId = 4 // India
            },
            new
            {
                Id = 3,
                Name = "Manzana",
                Price = 2.99m,
                ProducerCountryId = 1 // España
            },
            new
            {
                Id = 4,
                Name = "Manzana",
                Price = 2.99m,
                ProducerCountryId = 3 // EEUU
            },
            new
            {
                Id = 5,
                Name = "Aguacate",
                Price = 0.99m,
                ProducerCountryId = 2 // Cuba
            }
        );
    }
}
