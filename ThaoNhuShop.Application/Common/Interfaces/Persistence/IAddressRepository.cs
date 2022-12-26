using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface IAddressRepository
    {

        Task<List<Entity.Address>?> GetAllAddressByUserId(Guid id);

        Task<Entity.Address?> DeleteAddressById(Guid id);

        Task<Entity.Address?> CreateNewAddress(Entity.Address address);

        Task<Entity.Address?> UpdateAddress(Guid id, Entity.Address address);

        Task<Entity.Address?> SetAddressIsDefault(Guid id);

        Task<Entity.Address?> GetAddressById(Guid id);
    }
}