using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Queries
{
    public class GetFruitByIdQuery: IRequest<ErrorOr<Fruit?>>
    {
        public int Id { get; init; }
    }
}
