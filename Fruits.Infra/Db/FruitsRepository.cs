using Fruits.Domain;
using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Infra.Contexts;

namespace Fruits.Infra;

public class FruitsRepository(FruitsDbContext _context) : IFruitsRepository
{    public async Task<Fruit> AddAsync(Fruit entity)
    {
        var result = await _context.Fruits.AddAsync(entity);
        return result.Entity;
    }

    public IQueryable<Fruit> GetAll()
    {
        return _context.Fruits.AsQueryable();
    }
}
