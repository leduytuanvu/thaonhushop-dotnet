using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Infrastructure.Authentication;

namespace ThaoNhuShop.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public UserRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateNewUser(string phone, string password)
        {
            var passwordHasher = PasswordHasher.HashPassword(password);
            if(string.IsNullOrEmpty(passwordHasher))
            {
                return null;
            }
            var user = new User{
                Id = Guid.NewGuid(),
                Phone = phone,
                Password = passwordHasher
            };
            var response = await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();
            if(response is null)
            {
                return null;
            }
            return response.Entity;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var response = await _context.Users!.FirstOrDefaultAsync(u => u.Id == id);
            if(response is null)
            {
                return null;
            }
            return response;
        }

        public async Task<User?> GetUserByPhone(string phone)
        {
            var response = await _context.Users!.FirstOrDefaultAsync(u => u.Phone == phone);
            if(response is null)
            {
                return null;
            }
            return response;
        }

        public async Task<User?> GetUserByPhoneAndPassword(string phone, string password)
        {
            var passwordHasher = PasswordHasher.HashPassword(password);
            if(string.IsNullOrEmpty(passwordHasher))
            {
                return null;
            }
            var response = await _context.Users!.FirstOrDefaultAsync(u => u.Phone == phone && u.Password == passwordHasher);
            if(response is null)
            {
                return null;
            }
            return response;
        }
    }
}