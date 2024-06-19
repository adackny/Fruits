using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application;

public class CreateFruitCommand : IRequest<ErrorOr<Fruit>>
{
    public required string Name { get; init; }

    public required DateOnly Caducity { get; init; }

    public required List<string> Colors { get; init; }

    public Fruit ToFruitDomain() => new()
    {
        Name = Name,
        Caducity = Caducity,
        Colors = Colors
    };
}
