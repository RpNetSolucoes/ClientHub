using LibraryClienteHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientHub.Models
{
    public partial class ClientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um arquivo.")]
        [Display(Name = "Logo Tipo")]
        public IFormFile LogoType { get; set; }
        public ClientViewModel()
        {
        }
        public ClientViewModel(Clients data, IFormFile logo)
        {
            this.Id = data.Id;
            this.Name = data.Name;
            this.Email = data.Email;
            this.LogoType = logo;
        }
    }
    
}
