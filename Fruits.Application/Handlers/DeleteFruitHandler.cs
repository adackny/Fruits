using ErrorOr;
using Fruits.Application.Commands;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class DeleteFruitHandler : IRequestHandler<DeleteFruitCommand, ErrorOr<Fruit>>
    {
        private readonly FruitsService _fruitsService;

        public DeleteFruitHandler(FruitsService fruitsService)
        {
            _fruitsService = fruitsService;
        }

        public Task<ErrorOr<Fruit>> Handle(DeleteFruitCommand request, CancellationToken cancellationToken)
        {
            return _fruitsService.RemoveAsync(request.Id);
        }
    }
}
