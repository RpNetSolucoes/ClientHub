using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryClienteHub.Services
{
    public partial class ClientsServises : IClientsServises
    {
        private readonly DbClientHubContext _db;


        public ClientsServises(DbClientHubContext db)
        {
            _db = db;
        }
        public async Task<List<Clients>> GetClientsAsync()
        {
            return await _db.Clients.ToListAsync();
        }

        public async Task<Clients> GetIdAsync(int id)
        {
            return await _db.Clients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var addressesToDelete = await _db.AddressClient
                .Where(a => a.Client.Id == id)
                .ToListAsync();

            if (addressesToDelete.Any())
            {
                _db.AddressClient.RemoveRange(addressesToDelete);
            }

            var clientToDelete = await _db.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (clientToDelete != null)
            {
                _db.Clients.Remove(clientToDelete);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Clients> UpdateAsync(Clients client)
        {
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Clients> AddAsync(Clients client)
        {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Clients> GetEmailAsync(string email)
        {
            return await _db.Clients.FirstOrDefaultAsync(p => p.Email == email);
        }

    }
}
