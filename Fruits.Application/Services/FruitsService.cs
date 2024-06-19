using ErrorOr;
using FluentValidation;
using Fruits.Domain;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;

namespace Fruits.Application;

public class FruitsService(IValidator<Fruit> _validator, IFruitsUnitOfWork _unitOfWork)
{
    public async Task<ErrorOr<Fruit>> AddAsync(Fruit fruit)
    {
        var validationResult = _validator.Validate(fruit);

        if (!validationResult.IsValid)
        {
            var error = FruitError.InvalidModel;

            foreach (var validation in validationResult.Errors)
            {
                error.Metadata?.Add(validation.PropertyName, validation.ErrorMessage);
            }

            return error;
        }

        Fruit fruitResult = await _unitOfWork.FruitsRepository.AddAsync(fruit);
        await _unitOfWork.SaveChangesAsync();

        return fruitResult;
    }

    public async Task<ErrorOr<IEnumerable<Fruit>>> GetAllAsync()
    {
        var fruits = await _unitOfWork.FruitsRepository.GetAllAsyn();
        var result = ErrorOrFactory.From(fruits);

        return result;
    }
}
