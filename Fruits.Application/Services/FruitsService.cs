using ErrorOr;
using Fruits.Domain;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Domain.Validations;

namespace Fruits.Application;

public class FruitsService(CreateFruitValidator _createFruitValidator,
    UpdateFruitValidator _updateFruitValidator, 
    IFruitsUnitOfWork _unitOfWork)
{
    public async Task<ErrorOr<Fruit>> AddAsync(Fruit fruit)
    {
        var validationResult = _createFruitValidator.Validate(fruit);

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

    public async Task<ErrorOr<Fruit?>> UpdateAsync(Fruit fruit)
    {
        var validationResult = _updateFruitValidator.Validate(fruit);

        if (!validationResult.IsValid)
        {
            var error = FruitError.InvalidModel;

            foreach (var validation in validationResult.Errors)
            {
                error.Metadata?.Add(validation.PropertyName, validation.ErrorMessage);
            }

            return error;
        }

        IFruitsRepository fruitsRepository = _unitOfWork.FruitsRepository;
        Fruit? fruitResult = await fruitsRepository.GetByIdAsync(fruit.Id);

        if (fruitResult is null) return FruitError.FruitNotFound;

        fruitsRepository.Update(fruitResult);        
        await _unitOfWork.SaveChangesAsync();

        return fruitResult;
    }

    public async Task<ErrorOr<Fruit?>> GetByIdAsync(int id)
    {
        if (id <= 0) return CommonError.InvalidId;

        Fruit? fruit = await _unitOfWork.FruitsRepository.GetByIdAsync(id);

        if (fruit is null) return FruitError.FruitNotFound;

        return fruit;
    }

    public async Task<ErrorOr<IEnumerable<Fruit>>> ListAsync(int pageNumber, int pageSize)
    {
        var fruits = await _unitOfWork.FruitsRepository.ListAsync(pageNumber, pageSize);
        var result = ErrorOrFactory.From(fruits);

        return result;
    }

    public async Task<ErrorOr<Fruit>> RemoveAsync(int id)
    {
        if (id <= 0) return CommonError.InvalidId;

        IFruitsRepository fruitsRepository = _unitOfWork.FruitsRepository;
        Fruit? fruit = await fruitsRepository.GetByIdAsync(id);

        if (fruit is null) return FruitError.FruitNotFound;

        fruitsRepository.Remove(fruit);
        await _unitOfWork.SaveChangesAsync();

        return fruit;
    }
}
