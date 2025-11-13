using System.ComponentModel.DataAnnotations.Schema;

namespace Fruits.Infrastructure.Entities;

[Table("Seller")]
public class SellerEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
