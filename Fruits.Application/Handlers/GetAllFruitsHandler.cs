using ErrorOr;
using Fruits.Application.Queries;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class GetAllFruitsHandler : IRequestHandler<GetAllFruitsQuery, ErrorOr<IEnumerable<Fruit>>>
    {
        private readonly FruitsService _fruitsService;

        public GetAllFruitsHandler(FruitsService fruitsService)
        {
            _fruitsService = fruitsService;
        }

        public Task<ErrorOr<IEnumerable<Fruit>>> Handle(GetAllFruitsQuery request, CancellationToken cancellationToken)
        {
            return _fruitsService.ListAsync(request.PageNumber, request.PageSize);
        }
    }
}
