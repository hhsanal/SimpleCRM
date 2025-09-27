using Domain.Abstractions;
using Domain.Products;

namespace Domain.ProductCategories;

public class ProductCategory : ParameterEntity
{
    public ICollection<Product>? Products { get; set; }
}
