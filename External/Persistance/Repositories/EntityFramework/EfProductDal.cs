using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.EntityFramework
{
    public class EfProductDal : Repository<Product> , IProductDal
    {
        public EfProductDal(EfContext _context) : base(_context)
        {
        }

        public async Task<List<Product>> GetProductsWithParameters(CancellationToken cancellationToken = default)
        {
            var result = await context.Set<Product>()
                                      .Include(x=>x.Group)
                                      .Include(x=>x.Category)
                                      .Include(x=>x.Brand)
                                      .ToListAsync(cancellationToken);
            return result;
        }
    }
}
