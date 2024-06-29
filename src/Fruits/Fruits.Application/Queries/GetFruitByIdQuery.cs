using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Queries;

public record Provider(decimal Price, string Country);

public record FruitWithPrice(
    string Name,
    DateOnly Caducity,
    List<string> Colors,
    List<Provider> Providers)
{
    public decimal BestPrice => Providers.Min(p => p.Price);
}

public class GetFruitByIdQuery: IRequest<ErrorOr<FruitWithPrice?>>
{
    public int Id { get; init; }
}
