using ErrorOr;
using Fruits.Application.Queries;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class GetFruitsHandler : IRequestHandler<GetFruitsQuery, ErrorOr<IEnumerable<Fruit>>>
    {
        private readonly FruitsService _fruitsService;

        public GetFruitsHandler(FruitsService fruitsService)
        {
            _fruitsService = fruitsService;
        }

        public Task<ErrorOr<IEnumerable<Fruit>>> Handle(GetFruitsQuery request, CancellationToken cancellationToken)
        {
            return _fruitsService.GetAllAsync();
        }
    }
}
