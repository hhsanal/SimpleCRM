using Domain.ProductCategories;
using Persistance.Context;

namespace Persistance.Repositories.EntityFramework;

public class EfProductCategoryDal : Repository<ProductCategory>, IProductCategoryDal
{
    public EfProductCategoryDal(EfContext _context) : base(_context)
    {
    }
}
