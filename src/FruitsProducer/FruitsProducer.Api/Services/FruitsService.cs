using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitsProducer.Api;


public record class FruitDto(
    int Id,
    string Name,
    decimal Price,
    ProducerCountryDto ProducerCountry
);

public record class ProducerCountryDto(
    int Id,
    string Name
);

public class FruitsService(FruitsProducerDbContext _context)
{
    internal async IAsyncEnumerable<FruitDto> AllAsync(string fruitName)
    {
        var fruits = _context.Fruits
                .Where(f => f.Name.ToLower() == fruitName.ToLower())
                .Include(f => f.ProducerCountry)
                .AsAsyncEnumerable();

        await foreach (var fruit in fruits)
        {
            var producerCountry = fruit.ProducerCountry;
            yield return new FruitDto(
                fruit.Id,
                fruit.Name,
                fruit.Price,
                new ProducerCountryDto(
                    producerCountry.Id,
                    producerCountry.Name
                )
            );
        }
    }
}
