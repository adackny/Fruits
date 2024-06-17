using Fruits.Domain;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using MediatR;
using OneOf;

namespace Fruits.Application;

using CreateFruitResult = OneOf<Fruit, Error>;

public class CreateFruitHandler : IRequestHandler<CreateFruitCommand, CreateFruitResult>
{
    private readonly FruitsService _fruitsService;

    public CreateFruitHandler(FruitsService fruitsService)
    {
        _fruitsService = fruitsService;
    }


    public async Task<CreateFruitResult> Handle(
        CreateFruitCommand request, CancellationToken cancellationToken)
    {
        var fruit = request.ToFruitDomain();
        var fruitResult = await _fruitsService.AddAsync(fruit);

        return fruitResult;
    }
}
