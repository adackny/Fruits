namespace Fruits.Domain.Models;

public class Fruit
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public DateOnly Caducity { get; set; }

    public required List<string> Colors { get; set; }
}
