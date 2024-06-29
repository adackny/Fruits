using ErrorOr;
using FluentValidation;
using Fruits.Application.Commands;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application;

public class CreateFruitHandler : IRequestHandler<CreateFruitCommand, ErrorOr<Fruit>>
{
    private readonly FruitsService _fruitsService;
    private readonly IValidator<CreateFruitCommand> _validator;

    public CreateFruitHandler(FruitsService fruitsService, IValidator<CreateFruitCommand> validator)
    {
        _fruitsService = fruitsService;
        _validator = validator;
    }

    public async Task<ErrorOr<Fruit>> Handle(CreateFruitCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var error = FruitError.InvalidModel;

            foreach (var validation in validationResult.Errors)
            {
                error.Metadata?.Add(validation.PropertyName, validation.ErrorMessage);
            }

            return error;
        }

        Fruit fruit = request;
        ErrorOr<Fruit> result = await _fruitsService.AddAsync(fruit);

        return result;
    }
}
