// /Models/Product.cs
namespace ECommerce.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}