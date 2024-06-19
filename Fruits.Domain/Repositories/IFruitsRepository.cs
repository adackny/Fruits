using Fruits.Domain.Models;
using Fruits.Domain.Specifications;

namespace Fruits.Domain.Repositories;

public interface IFruitsRepository
{
    Task<Fruit> AddAsync(Fruit entity);
    Task<Fruit?> GetByIdAsync(int id);
    Task<IEnumerable<Fruit>> ListAsyn(int pageNumber, int pageSize);
}
