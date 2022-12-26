using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Infrastructure.Persistence
{
    public class ProductItemRepository : IProductItemRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public ProductItemRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<ProductItem?> CreateNewProductItem(ProductItem productItem)
        {
            var response = await _context.ProductItems!.AddAsync(productItem);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<List<ProductItem>?> GetAllProductItem()
        {
            var response = await _context.ProductItems!.Select(x => x).ToListAsync();
            return response;
        }

        public async Task<ProductItem?> GetProductItemById(Guid id)
        {
            var response = await _context.ProductItems!.FindAsync(id);
            return response;
        }

        public async Task<List<ProductItem>?> GetProductItemByProductId(Guid id)
        {
            var response = await _context.ProductItems!.Select(x => x).Where(x => x.ProductId == id).ToListAsync();
            return response;
        }
    }
}