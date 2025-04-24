// In Services/ProductService.cs
using ECommerce;
using System;

public class ProductService
{
    private readonly AppDbContext _context;
    private readonly ICacheService _cache;

    public ProductService(AppDbContext context, ICacheService cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<Product>> GetFeaturedProductsAsync(int count = 6)
    {
        var cacheKey = $"featured_products_{count}";

        return await _cache.GetOrCreateAsync(cacheKey, async entry => {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            return await _context.Products
                .Where(p => p.IsFeatured)
                .OrderByDescending(p => p.PopularityScore)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        });
    }
}