using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Infrastructure.Persistence
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ThaoNhuShopDbContext _context;

        public AddressRepository(ThaoNhuShopDbContext context)
        {
            _context = context;
        }

        public async Task<Address?> CreateNewAddress(Address address)
        {
            var response = await _context.Addresses!.AddAsync(address);
            if(response is null)
            {
                return null;
            }
            return response.Entity;
        }

        public async Task<Address?> DeleteAddressById(Guid id)
        {
            var response = await _context.Addresses!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            var responseDelete = _context.Addresses!.Remove(response);
            await _context.SaveChangesAsync();
            if(responseDelete is null)
            {
                return null;
            }
            return responseDelete.Entity;
        }

        public async Task<Address?> GetAllAddressByUserId(Guid id)
        {
            var response = await  _context.Addresses!.FirstOrDefaultAsync(x => x.UserId == id);
            if(response is null)
            {
                return null;
            }
            return response;
        }

        public async Task<Address?> SetAddressIsDefault(Guid id)
        {
            var response = await _context.Addresses!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            response.IsDefault = true;
            var responseUpdate = _context.Addresses!.Update(response);
            await _context.SaveChangesAsync();
            if(responseUpdate is null)
            {
                return null;
            }
            return responseUpdate.Entity;
        }

        public async Task<Address?> UpdateAddress(Guid id, Address address)
        {
            var response = await _context.Addresses!.FindAsync(id);
            if(response is null)
            {
                return null;
            }
            var responseUpdate = _context.Addresses!.Update(address);
            await _context.SaveChangesAsync();
            if(responseUpdate is null)
            {
                return null;
            }
            return responseUpdate.Entity;
        }
    }
}