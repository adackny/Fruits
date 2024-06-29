using ErrorOr;
using FluentValidation;
using Fruits.Domain;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Domain.Validations;

namespace Fruits.Application;

public class FruitsService(IFruitsUnitOfWork _unitOfWork)
{
    public async Task<ErrorOr<Fruit>> AddAsync(Fruit fruit)
    {
        Fruit fruitResult = await _unitOfWork.FruitsRepository.AddAsync(fruit);
        await _unitOfWork.SaveChangesAsync();

        return fruitResult;
    }

    public async Task<ErrorOr<Fruit?>> UpdateAsync(Fruit fruit)
    {
        IFruitsRepository fruitsRepository = _unitOfWork.FruitsRepository;
        Fruit? existingFruit = await fruitsRepository.GetByIdAsync(fruit.Id);

        if (existingFruit is null)
            return FruitError.FruitNotFound;

        if (fruit.Caducity < existingFruit.Caducity
            && fruit.Caducity < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            return FruitError.InvalidModel;
        }

        existingFruit.Name = fruit.Name;
        existingFruit.Caducity = fruit.Caducity;
        existingFruit.Colors = fruit.Colors;

        fruitsRepository.Update(existingFruit);
        await _unitOfWork.SaveChangesAsync();

        return existingFruit;
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
