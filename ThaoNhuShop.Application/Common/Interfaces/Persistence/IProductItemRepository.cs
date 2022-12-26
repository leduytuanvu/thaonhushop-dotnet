using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface IProductItemRepository
    {
        Task<ProductItem?> GetProductItemById(Guid id);

        Task<List<ProductItem>?> GetAllProductItem();

        Task<List<ProductItem>?> GetProductItemByProductId(Guid id);

        Task<ProductItem?> CreateNewProductItem(ProductItem productItem);

        // Task<List<ProductItem>?> GetProductItemByColorId(Guid id);

        // Task<List<ProductItem>?> GetProductItemBySizeId(Guid id);

        // Task<List<ProductItem>?> GetProductItemByColorIdAndSizeId(Guid colorId, Guid sizeId);

        // Task<List<ProductItem>?> GetProductItemByProductIdAndColorId(Guid productId, Guid colorId);
    }
}