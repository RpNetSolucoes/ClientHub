using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryClienteHub.Interface
{
    public interface IClientsServises 
    {
        Task<List<Clients>> GetClientsAsync();
        Task<Clients> GetIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Clients> UpdateAsync(Clients client);
        Task<Clients> AddAsync(Clients client);
        Task<Clients> GetEmailAsync(string email);
    }
}
