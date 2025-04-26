// /Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}