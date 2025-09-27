using Domain.Abstractions;
using Domain.ProductBrands;
using Domain.Products;

namespace Domain.ProductGroups;

public class ProductGroup : ParameterEntity
{
    public ICollection<Product>? Products { get; set; }
}
