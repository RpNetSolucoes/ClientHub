using LibraryClienteHub.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryClienteHub.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string PassWord { get; set; }
    }

}
