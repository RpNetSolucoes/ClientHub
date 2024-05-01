using LibraryClienteHub.Interface;
using LibraryClienteHub.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LibraryClienteHub.Models
{
    public partial class AddressClientService : IAddressClientServices
    {
        private readonly DbClientHubContext _db;

        public AddressClientService(DbClientHubContext db)
        {
            _db = db;
        }
        public async Task<List<AddressClient>> GetAddressClientAsync()
        {
            return await _db.AddressClient.Include(a => a.Client).ToListAsync();
        }

        public async Task<AddressClient> GetIdAsync(int id)
        {
            return await _db.AddressClient
                            .Include(a => a.Client)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AddressClient> UpdateAsync(AddressClient address)
        {
            _db.Entry(address).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return address;
        }

        public async Task<AddressClient> AddAsync(AddressClient address)
        {
            _db.AddressClient.Add(address);
            await _db.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var addressToDelete = await _db.AddressClient.FirstOrDefaultAsync(c => c.Id == id);

            if (addressToDelete != null)
            {
                _db.AddressClient.Remove(addressToDelete);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
