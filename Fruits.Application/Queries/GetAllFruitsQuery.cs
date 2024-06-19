using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Queries;

public class GetAllFruitsQuery : IRequest<ErrorOr<IEnumerable<Fruit>>>
{
    private const int MAX_PAGE_SIZE = 20;

    private int _pageNumber = 1;
    private int _pageSize = MAX_PAGE_SIZE;

    public int PageNumber
    {
        get => _pageNumber;
        init => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
    }
}
