using Fruits.Common;

namespace Fruits.Domain.Models;

public class Seller(int id, string name, List<Fruit> fruits)
{
    public int Id => id;
    public string Name => name;
    public List<Fruit> Fruits => fruits;

    public OperationResult<Unit> BuyFruit(int fruitId, int quantity)
    {
        var fruit = fruits.FirstOrDefault(f => f.Id == fruitId);

        if (fruit is null)
            return new OperationError($"Seller '{name}' has not fruit with id: {fruitId}");

        if (fruit.QuantityInStock < quantity)
            return new OperationError($"Seller '{name}' has not enough '{fruit.Name}' fruits");

        fruit.QuantityInStock -= quantity;

        return Unit.Value;
    }
}
