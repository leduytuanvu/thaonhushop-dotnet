using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface IProductImageRepository
    {
        Task<List<Entity.ProductImage>?> GetAllProductImage();

        Task<Entity.ProductImage?> CreateNewProductImage(Entity.ProductImage productImage);
    }
}