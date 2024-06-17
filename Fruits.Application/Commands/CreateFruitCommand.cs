using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using MediatR;
using OneOf;

namespace Fruits.Application;

using CreateFruitResult = OneOf<Fruit, Error>;

public class CreateFruitCommand : IRequest<CreateFruitResult>
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
