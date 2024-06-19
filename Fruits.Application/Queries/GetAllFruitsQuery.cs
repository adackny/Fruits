using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Queries;

public class GetAllFruitsQuery : IRequest<ErrorOr<IEnumerable<Fruit>>>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
