using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Queries;

public class GetFruitsQuery : IRequest<ErrorOr<IEnumerable<Fruit>>>
{
}
