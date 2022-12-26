using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public ProductRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> CreateNewProduct(Product product)
        {
            var response = await _context.Products!.AddAsync(product);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<List<Product>?> GetAllProduct()
        {
            var response = await _context.Products!.Select(x => x).ToListAsync();
            return response;
        }

        public async Task<List<Product>?> GetProductByBrandId(Guid id)
        {
            var response = await _context.Products!.Select(x => x).Where(x => x.BrandId == id).ToListAsync();
            return response;
        }

        public async Task<List<Product>?> GetProductByCategoryId(Guid id)
        {
            var response = await _context.Products!.Select(x => x).Where(x => x.CategoryId == id).ToListAsync();
            return response;
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            var response = await _context.Products!.FindAsync(id);
            return response;
        }
    }
}