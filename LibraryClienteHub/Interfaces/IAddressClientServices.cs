using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryClienteHub.Interface
{
    public interface IAddressClientServices
    {
        Task<List<AddressClient>> GetAddressClientAsync();
        Task<AddressClient> GetIdAsync(int id);
        Task<AddressClient> UpdateAsync(AddressClient address);
        Task<AddressClient> AddAsync(AddressClient address);
        Task<bool> DeleteAsync(int id);

    }
}
