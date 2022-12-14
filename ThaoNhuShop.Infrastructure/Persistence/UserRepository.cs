using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ThaoNhuShop.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public UserRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(string phone, string password, string fullName)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Phone = phone;
            user.Password = password;
            user.FullName = fullName;
            var response = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone);
        }

        public async Task<User?> GetUserByPhoneAndPassword(string phone, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone && u.Password == password);
        }
    }
}