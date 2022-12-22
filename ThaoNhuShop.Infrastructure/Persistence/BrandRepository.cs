using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Infrastructure.Persistence.Interceptors
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public BrandRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<Brand?> CreateNewBrand(Brand brand)
        {
            var response = await _context.Brands!.AddAsync(brand);
            await _context.SaveChangesAsync();
            if(response is null)
            {
                return null;
            }
            return response.Entity;
        }

        public async Task<Brand?> DeleteBrandById(Guid id)
        {
            var response = await _context.Brands!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            var responseDelete = _context.Brands!.Remove(response);
            await _context.SaveChangesAsync();
            if(responseDelete is null)
            {
                return null;
            }
            return responseDelete.Entity;
        }

        public async Task<List<Brand>?> GetAllBrand()
        {
            var list = await _context.Brands!.Select(x => x).ToListAsync();
            if(list is null)
            {
                return null;
            }
            return list;
        }

        public async Task<Brand?> GetBrandById(Guid id)
        {
            var response =  await _context.Brands!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            return response;
        }
    }
}