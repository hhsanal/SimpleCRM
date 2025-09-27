using Domain.ProductBrands;
using Domain.ProductCategories;
using Domain.ProductGroups;
using Domain.Products;
using Domain.ProductUnits;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context;

public partial class EfContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<ProductUnit> ProductUnits { get; set; }
}
