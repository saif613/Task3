using System;
using System.Collections.Generic;
using System.Text;
using Task3.Domain.Entity;

namespace Task3.Application.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);

        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task AddAsync(Product product, CancellationToken cancellationToken);
    }
}
