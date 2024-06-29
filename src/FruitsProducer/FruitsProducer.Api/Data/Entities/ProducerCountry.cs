namespace FruitsProducer.Api;

public class ProducerCountry
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Fruit> Fruits { get; set; }
}
