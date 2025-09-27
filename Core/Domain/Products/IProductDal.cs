using Domain.Abstractions;

namespace Domain.Products;

public interface IProductDal : IRepository<Product>
{
    Task<List<Product>> GetProductsWithParameters(CancellationToken cancellationToken = default);
}
