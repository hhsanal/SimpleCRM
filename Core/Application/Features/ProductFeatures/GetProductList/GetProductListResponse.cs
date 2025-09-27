using Domain.Products;

namespace Application.Features.ProductFeatures.GetProductList;

public class GetProductListResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BrandName { get; set; } = "-";
    public string GroupName { get; set; } = "-";
    public string CategoryName { get; set; } = "-";
    public string? ImageUrl { get; set; }
    public string? TechnicalDocumentUrl { get; set; }
    public CurrencyTypes CurrencyType { get; set; }
    public decimal VatRate { get; set; }
    public decimal DefaultDiscountRate { get; set; }
}
