using Fruits.Domain.Models;

namespace Fruits.Domain.Repositories;

public interface IFruitsRepository
{
    Task<Fruit> GetByIdAsync(int id);
    Task<IEnumerable<Fruit>> GetAllAsync();
    Task<int> AddAsync(Fruit fruit);
}
