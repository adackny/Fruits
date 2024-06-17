using FluentValidation;
using Fruits.Domain;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using OneOf;

namespace Fruits.Application;

using CreateFruitResult = OneOf<Fruit, Error>;

public class FruitsService(IValidator<Fruit> _validator, IFruitsUnitOfWork _unitOfWork)
{
    public async Task<CreateFruitResult> AddAsync(Fruit fruit)
    {

        var validationResult = _validator.Validate(fruit);
        if (!validationResult.IsValid)
        {
            var error = new ValidationError("fruit-validation", "Fruit model validation failed.", []);

            foreach (var validation in validationResult.Errors)
            {
                error.Details.Add(validation.PropertyName, validation.ErrorMessage);
            }

            return error;
        }

        var fruitResult = await _unitOfWork.FruitsRepository.AddAsync(fruit);
        await _unitOfWork.SaveChangesAsync();

        return fruitResult;
    }
}
