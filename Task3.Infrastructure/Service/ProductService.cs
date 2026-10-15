using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.Interface;
using Task3.Domain.Entity;
using Task3.Infrastructure.Persistence;

namespace Task3.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly TaskDb3 _context;

        public ProductService(TaskDb3 context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    p => p.Id == id && !p.IsDeleted,
                    cancellationToken);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(
                product,
                cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
