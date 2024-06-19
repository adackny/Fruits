using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Fruits.Infra;

public class FruitsRepository(FruitsDbContext _context) : IFruitsRepository
{
    public async Task<Fruit> AddAsync(Fruit entity)
    {
        var result = await _context.Fruits.AddAsync(entity);

        return result.Entity;
    }

    public async Task<IEnumerable<Fruit>> ListAsyn(int pageNumber, int pageSize)
    {
        return await _context.Fruits
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
