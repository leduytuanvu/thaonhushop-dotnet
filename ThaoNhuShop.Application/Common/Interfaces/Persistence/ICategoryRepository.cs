using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface ICategoryRepository
    {
        Task<Entity.Category?> GetCategoryById(Guid id);

        Task<List<Entity.Category>?> GetAllCategory();

        Task<Entity.Category?> DeleteCategoryById(Guid id);

        Task<Entity.Category?> CreateNewCategory(Entity.Category category);
    }
}