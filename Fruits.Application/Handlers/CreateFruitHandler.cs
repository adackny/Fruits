using ErrorOr;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application;

public class CreateFruitHandler : IRequestHandler<CreateFruitCommand, ErrorOr<Fruit>>
{
    private readonly FruitsService _fruitsService;

    public CreateFruitHandler(FruitsService fruitsService)
    {
        _fruitsService = fruitsService;
    }

    public async Task<ErrorOr<Fruit>> Handle(CreateFruitCommand request, CancellationToken cancellationToken)
    {
        Fruit fruit = request;
        ErrorOr<Fruit> result = await _fruitsService.AddAsync(fruit);

        return result;
    }
}
