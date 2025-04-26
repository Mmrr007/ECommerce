// /Services/ProductService.cs
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Services;

public class ProductService(AppDbContext context)
{
    public List<Product> GetAllProducts() => context.Products.ToList();

    public List<Product> GetFeaturedProducts() =>
        context.Products.Where(p => p.IsFeatured).ToList();

    internal List<Product> Getproducts()
    {
        throw new NotImplementedException();
    }
}