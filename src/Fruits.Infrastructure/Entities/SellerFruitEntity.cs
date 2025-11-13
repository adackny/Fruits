using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fruits.Infrastructure.Entities;

[Table("SellerFruit")]
public class SellerFruitEntity
{
    [Key]
    public int SellerId { get; set; }
    [Key]
    public int FruitId { get; set; }
    public int QuantityInStock { get; set; }
    public required SellerEntity Seller { get; set; }
    public required FruitEntity Fruit { get; set; }
}
