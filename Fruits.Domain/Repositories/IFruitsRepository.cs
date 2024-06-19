using Fruits.Domain.Models;

namespace Fruits.Domain.Repositories;

public interface IFruitsRepository
{
    Task<Fruit> AddAsync(Fruit entity);

    Task<IEnumerable<Fruit>> ListAsync(int pageNumber, int pageSize);
}
