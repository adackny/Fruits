using Fruits.Domain.Models;

namespace Fruits.Domain.Repositories;

public interface IFruitsSellerRepository
{
    Task<Seller> GetByIdAsync(int id);
    Task<IEnumerable<Seller>> GetAllAsync();
}
