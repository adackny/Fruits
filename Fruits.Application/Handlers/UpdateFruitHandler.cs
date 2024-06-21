using ErrorOr;
using Fruits.Application.Commands;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class UpdateFruitHandler : IRequestHandler<UpdateFruitCommand, ErrorOr<Fruit?>>
    {
        private readonly FruitsService _fruitsService;

        public UpdateFruitHandler(FruitsService fruitsService)
        {
            _fruitsService = fruitsService;
        }

        public async Task<ErrorOr<Fruit?>> Handle(UpdateFruitCommand request, CancellationToken cancellationToken)
        {
            Fruit fruit = request;
            ErrorOr<Fruit?> result = await _fruitsService.UpdateAsync(fruit);

            return result;
        }
    }
}
