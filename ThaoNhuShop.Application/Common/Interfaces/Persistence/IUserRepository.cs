using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByPhone(string phone);

        Task<User?> GetUserById(Guid id);

        Task<User?> GetUserByPhoneAndPassword(string phone, string password);

        Task<User?> CreateUser(string phone, string password, string fullName);
    }
}