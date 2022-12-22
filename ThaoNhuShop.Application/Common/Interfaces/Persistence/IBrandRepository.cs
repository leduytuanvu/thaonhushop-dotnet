using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface IBrandRepository
    {
        Task<Entity.Brand?> GetBrandById(Guid id);

        Task<Entity.Brand?> DeleteBrandById(Guid id);

        Task<List<Entity.Brand>?> GetAllBrand();

        Task<Entity.Brand?> CreateNewBrand(Entity.Brand brand);
    }
}