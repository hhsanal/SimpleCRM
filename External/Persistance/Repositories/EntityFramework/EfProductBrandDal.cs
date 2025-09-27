using Domain.ProductBrands;
using Persistance.Context;

namespace Persistance.Repositories.EntityFramework;

public class EfProductBrandDal : Repository<ProductBrand>, IProductBrandDal
{
    public EfProductBrandDal(EfContext _context) : base(_context)
    {
    }
}
