using Domain.ProductGroups;
using Persistance.Context;

namespace Persistance.Repositories.EntityFramework;

public class EfProductGroupDal : Repository<ProductGroup>, IProductGroupDal
{
    public EfProductGroupDal(EfContext _context) : base(_context)
    {
    }
}
