using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Commands
{
    public class UpdateFruitCommand : IRequest<ErrorOr<Fruit?>>
    {
        public int Id { get; set; }

        public required string Name { get; init; }

        public DateOnly Caducity { get; init; }

        public required List<string> Colors { get; init; }

        public static implicit operator Fruit(UpdateFruitCommand updateFruitCommand)
        {
            return new Fruit
            {
                Id = updateFruitCommand.Id,
                Name = updateFruitCommand.Name,
                Caducity = updateFruitCommand.Caducity,
                Colors = updateFruitCommand.Colors
            };
        }
    }
}
