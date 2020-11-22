using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RichModel.Domain.Products;
using RichModel.Persistance.Database.Configurations;

namespace RichModel.Persistance.Products
{
    internal sealed class ProductRepository : IProductsRepository
    {
        private readonly OrdersDbContext _context;

        public ProductRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAsync(IEnumerable<Guid> productsIds,
            CancellationToken cancellationToken = default)
        {
            return await _context.Products.Where(product => productsIds.Contains(product.Id))
                .ToListAsync(cancellationToken);
        }
    }
}