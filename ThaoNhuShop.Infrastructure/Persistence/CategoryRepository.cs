using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public CategoryRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<Entity.Category?> CreateNewCategory(Entity.Category category)
        {
            var response = await _context.Categories!.AddAsync(category);
            await _context.SaveChangesAsync();
            if(response is null)
            {
                return null;
            }
            return response.Entity;
        }

        public async Task<Entity.Category?> GetCategoryById(Guid id)
        {
            var response = await _context.Categories!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            return response;
        }

        public async Task<List<Entity.Category>?> GetAllCategory()
        {
            var list = await _context.Categories!.Select(x => x).ToListAsync();
            if(list is null)
            {
                return null;
            }
            return list;
        }

        public async Task<Category?> DeleteCategoryById(Guid id)
        {
            var response = await _context.Categories!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            var responseDelete = _context.Categories!.Remove(response);
            await _context.SaveChangesAsync();
            if(responseDelete is null)
            {
                return null;
            }
            return responseDelete.Entity;
        }
    }
}