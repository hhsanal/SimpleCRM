using Domain.Abstractions;
using Domain.ProductCategories;
using Domain.Products;

namespace Domain.ProductUnits;

public class ProductUnit : ParameterEntity
{
    public ICollection<Product>? Products { get; set; }
}
