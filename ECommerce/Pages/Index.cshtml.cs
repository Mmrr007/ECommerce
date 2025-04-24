using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Product> FeaturedProducts { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                FeaturedProducts = await _context.Products
                    .Where(p => p.IsFeatured && p.StockQuantity > 0)
                    .OrderByDescending(p => p.CreatedDate)
                    .Take(6)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading featured products");
                // Fail gracefully - empty list is already initialized
            }
        }
    }
}