namespace Fruits.Infrastructure.Entities;

public class FruitEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly Caducity { get; set; }
}
