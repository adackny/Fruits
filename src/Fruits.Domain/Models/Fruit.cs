namespace Fruits.Domain.Models;

public record class Fruit(int Id, string Name, DateOnly Caducity, int QuantityInStock)
{
    public int QuantityInStock { get; set; } = QuantityInStock;
}
