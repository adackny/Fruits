using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application;

public class CreateFruitCommand : IRequest<ErrorOr<Fruit>>
{
    public required string Name { get; set; }

    public required DateOnly Caducity { get; set; }

    public required List<string> Colors { get; set; }

    public Fruit ToFruitDomain() => new()
    {
        Name = Name,
        Caducity = Caducity,
        Colors = Colors
    };
}
