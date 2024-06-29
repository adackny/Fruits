namespace Fruits.Application;

public record class TradingFruit(int Id, string Name, decimal Price);

public interface ITradingFruitsService
{
    Task<List<TradingFruit>?> GetFruitsAsync(string name);
}
