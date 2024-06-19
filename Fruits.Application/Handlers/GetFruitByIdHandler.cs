using ErrorOr;
using Fruits.Application.Queries;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class GetFruitByIdHandler : IRequestHandler<GetFruitByIdQuery, ErrorOr<Fruit?>>
    {
        private readonly FruitsService _fruitsService;

        public GetFruitByIdHandler(FruitsService fruitsService)
        {
            _fruitsService = fruitsService;
        }

        public Task<ErrorOr<Fruit?>> Handle(GetFruitByIdQuery request, CancellationToken cancellationToken)
        {
           return _fruitsService.GetByIdAsync(request.Id);
        }
    }
}
