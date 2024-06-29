using ErrorOr;
using Fruits.Application.Queries;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class GetFruitByIdHandler : IRequestHandler<GetFruitByIdQuery, ErrorOr<FruitWithPrice?>>
    {
        private readonly FruitsService _fruitsService;
        private readonly ITradingFruitsService _tradingFruitsService;

        public GetFruitByIdHandler(FruitsService fruitsService, ITradingFruitsService tradingFruitsService)
        {
            _fruitsService = fruitsService;
            _tradingFruitsService = tradingFruitsService;
        }

        public async Task<ErrorOr<FruitWithPrice?>> Handle(GetFruitByIdQuery request, CancellationToken cancellationToken)
        {
            var fruitResult = await _fruitsService.GetByIdAsync(request.Id);

            if (fruitResult.IsError)
            {
                return fruitResult.Errors;
            }

            var fruit = fruitResult.Value!;
            var tradingFruits = await _tradingFruitsService.GetFruitsAsync(fruit.Name);

            var fruitWithPrice = new FruitWithPrice(
                Name: fruit.Name,
                Caducity: fruit.Caducity,
                Colors: fruit.Colors,
                Providers: [
                    ..tradingFruits?.Select(tf => new Provider(tf.Price, tf.ProducerCountry.Name)) ?? [],
                ]
            );

            return fruitWithPrice;
        }
    }
}
