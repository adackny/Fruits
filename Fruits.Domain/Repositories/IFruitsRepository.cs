using Fruits.Domain.Models;

namespace Fruits.Domain.Repositories;

public interface IFruitsRepository
{
    Task<Fruit> AddAsync(Fruit entity);

    IQueryable<Fruit> GetAll();
}
