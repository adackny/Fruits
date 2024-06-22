using Fruits.Domain.Models;

namespace Fruits.Domain.Repositories;

public interface IFruitsRepository
{
    Task<Fruit> AddAsync(Fruit entity);
    Task<Fruit?> UpdateAsync(Fruit entity);
    Task<Fruit?> GetByIdAsync(int id);
    Task<IEnumerable<Fruit>> ListAsync(int pageNumber, int pageSize);
    void Remove(Fruit entity);
}
