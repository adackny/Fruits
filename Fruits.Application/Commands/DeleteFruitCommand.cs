using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Commands
{
    public class DeleteFruitCommand : IRequest<ErrorOr<Fruit>>
    {
        public int Id { get; init; }
    }
}
