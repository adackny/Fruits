using Fruits.Domain.Models;

namespace Fruits.Domain.Repositories;

public interface IFruitsRepository
{
    Task<Fruit> AddAsync(Fruit entity);

    Task<IEnumerable<Fruit>> ListAsyn(int pageNumber, int pageSize);
}
