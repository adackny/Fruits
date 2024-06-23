using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Commands;

public class CreateFruitCommand : IRequest<ErrorOr<Fruit>>
{
    public required string Name { get; init; }

    public DateOnly Caducity { get; init; }

    public required List<string> Colors { get; init; }

    public static implicit operator Fruit(CreateFruitCommand createFruitCommand)
    {
        return new Fruit
        {
            Name = createFruitCommand.Name,
            Caducity = createFruitCommand.Caducity,
            Colors = createFruitCommand.Colors
        };
    }
}
