namespace Fruits.Application;

public record class ProducerCountry(int Id, string Name);
public record class TradingFruit(int Id, string Name, decimal Price, ProducerCountry ProducerCountry);

public interface ITradingFruitsService
{
    Task<List<TradingFruit>?> GetFruitsAsync(string name);
}
