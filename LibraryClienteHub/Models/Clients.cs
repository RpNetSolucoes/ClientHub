using LibraryClienteHub.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryClienteHub.Models
{
    public partial class Clients 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] LogoType { get; set; }

        [NotMapped]
        public IFormFile Logofile { get; set; }
    }

}
