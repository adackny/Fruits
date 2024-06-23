namespace FruitsProducer.Api;

public class Fruit
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public ProducerCountry ProducerCountry { get; set; }
}
