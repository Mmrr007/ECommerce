using System.Collections.Generic;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _productService;  // Correct field name with underscore
        public List<Product> Products { get; set; } = new List<Product>();  // Initialize list

        public ProductsModel(ProductService productService)
        {
            _productService = productService;  // Correct assignment
        }

        public void OnGet()
        {
            Products = _productService.Getproducts();  // Correct field usage
        }
    }
}