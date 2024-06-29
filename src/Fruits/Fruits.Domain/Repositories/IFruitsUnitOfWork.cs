using Fruits.Domain.Repositories;

namespace Fruits.Domain;

public interface IFruitsUnitOfWork
{
    IFruitsRepository FruitsRepository { get; }

    Task<int> SaveChangesAsync();
}
