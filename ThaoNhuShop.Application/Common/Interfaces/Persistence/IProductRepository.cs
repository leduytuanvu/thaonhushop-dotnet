using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<Entity.Product?> GetProductById(Guid id);

        Task<List<Entity.Product>?> GetAllProduct();

        Task<List<Entity.Product>?> GetProductByCategoryId(Guid id);

        Task<List<Entity.Product>?> GetProductByBrandId(Guid id);

        Task<Entity.Product?> CreateNewProduct(Entity.Product product);

        // Task<List<Product>?> GetProductByPriceRange(decimal min, decimal max);

        // Task<List<Product>?> GetProductByPriceRangeAndCategoryId(decimal min, decimal max, Guid id);

        // Task<List<Product>?> GetProductByPriceRangeAndBrandId(decimal min, decimal max, Guid id);

        // Task<List<Product>?> GetProductByPriceRangeAndCategoryIdAndBrandId(decimal min, decimal max, Guid categoryId, Guid brandId);

        // Task<List<Product>?> GetProductByCategoryIdAndBrandId(Guid categoryId, Guid brandId);

        // Task<List<Product>?> GetProductBySearch(string search);

        // Task<List<Product>?> GetProductBySearchAndCategoryId(string search, Guid id);

        // Task<List<Product>?> GetProductBySearchAndBrandId(string search, Guid id);

        // Task<List<Product>?> GetProductBySearchAndCategoryIdAndBrandId(string search, Guid categoryId, Guid brandId);

        // Task<List<Product>?> GetProductBySearchAndPriceRange(string search, decimal min, decimal max);

        // Task<List<Product>?> GetProductBySearchAndPriceRangeAndCategoryId(string search, decimal min, decimal max, Guid id);

        // Task<List<Product>?> GetProductBySearchAndPriceRangeAndBrandId(string search, decimal min, decimal max, Guid id);

        // Task<List<Product>?> GetProductBySearchAndPriceRangeAndCategoryIdAndBrandId(string search, decimal min, decimal max, Guid categoryId, Guid brand);
    }
}