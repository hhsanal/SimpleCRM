using Domain.Abstractions;
using Domain.ProductBrands;
using Domain.ProductCategories;
using Domain.ProductGroups;
using Domain.ProductUnits;

namespace Domain.Products;

public class Product : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid BrandId { get; set; }
    public ProductBrand? Brand { get; set; }
    public string? Barcode { get; set; }
    public Guid UnitId { get; set; }
    public ProductUnit? Unit { get; set; }
    public decimal VatRate { get; set; }
    public decimal DefaultDiscountRate { get; set; }
    public Guid CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
    public Guid GroupId { get; set; }
    public ProductGroup? Group { get; set; }
    public string? ImageUrl { get; set; }
    public string? TechnicalDocumentUrl { get; set; }
    public CurrencyTypes CurrencyType { get; set; }
}
