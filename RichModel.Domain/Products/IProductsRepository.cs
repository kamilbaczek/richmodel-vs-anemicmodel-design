using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RichModel.Domain.Products
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAsync(IEnumerable<Guid> productsIds,
            CancellationToken cancellationToken = default);
    }
}