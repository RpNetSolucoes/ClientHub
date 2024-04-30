using LibraryClienteHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClientHub.Models
{
    public partial class AddressClientViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        [DisplayName("Rua")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [DisplayName("Número")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [DisplayName("CEP")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [DisplayName("Cidade")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [DisplayName("Estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo País é obrigatório.")]
        [DisplayName("País")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        [DisplayName("Cliente")]
        public int ClientId { get; set; }

        public List<Clients> Clients { get; set; }

        public AddressClientViewModel()
        {
            Clients = new List<Clients>();
        }
        public AddressClientViewModel(AddressClient data)
        {
            this.Id = data.Id;
            this.Street = data.Street;
            this.Number = data.Number;
            this.Neighborhood = data.Neighborhood;
            this.ZipCode = data.ZipCode;
            this.City = data.City;
            this.State = data.State;
            this.Country = data.Country;
            this.ClientId = data.Client.Id;
            this.Clients = new List<Clients>();

        }

    }
}
