using Fruits.Domain;
using Fruits.Domain.Repositories;
using Fruits.Infra.Contexts;

namespace Fruits.Infra;

public class FruitsUnitOfWork : IFruitsUnitOfWork, IDisposable
{
    private readonly FruitsDbContext _context;
    private readonly IFruitsRepository _fruitsRepository;

    public FruitsUnitOfWork(FruitsDbContext context, IFruitsRepository fruitsRepository)
    {
        _context = context;
        _fruitsRepository = fruitsRepository;
    }

    public IFruitsRepository FruitsRepository => _fruitsRepository;

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
       _context.Dispose();
    }
}
