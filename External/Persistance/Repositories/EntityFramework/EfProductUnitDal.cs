using Domain.ProductUnits;
using Persistance.Context;

namespace Persistance.Repositories.EntityFramework;

public class EfProductUnitDal : Repository<ProductUnit>, IProductUnitDal
{
    public EfProductUnitDal(EfContext _context) : base(_context)
    {
    }
}
