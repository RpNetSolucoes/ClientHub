using LibraryClienteHub.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryClienteHub.Models
{
    public partial class AuthToken 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Client { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
