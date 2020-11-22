using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AnemicModel.Domain.Products;

namespace AnemicModel.Application.Products
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAsync(IEnumerable<Guid> productsIds,
            CancellationToken cancellationToken = default);
    }
}