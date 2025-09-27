using Domain.Abstractions;
using Domain.Products;


namespace Domain.ProductBrands;

public class ProductBrand: ParameterEntity
{
    public ICollection<Product>? Products { get; set; }
}
