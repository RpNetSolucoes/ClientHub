using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryClienteHub.Models
{
    public partial class AddressClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public Clients Client { get; set; }

    }
}
