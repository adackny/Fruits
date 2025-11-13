using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Infrastructure.Contexts;

namespace Fruits.Infrastructure.Repositories;

public class SellerRepository(FruitsDbContext context) : ISellerRepository
{
    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Seller> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
