using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientHub.Models;
using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using LibraryClienteHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiClientHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressClientController : ControllerBase
    {
        private readonly IAddressClientServices _addressClientServices;
        private readonly IClientsServises _clientsServises;
        public AddressClientController(IAddressClientServices addressClientServices, IClientsServises clientsServises)
        {
            _addressClientServices = addressClientServices;
            _clientsServises = clientsServises;
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Obtém todos os endereços de clientes", Description = "Retorna uma lista de todos os endereços de clientes cadastrados.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(IEnumerable<AddressClient>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Não encontrado")]
        public async Task<ActionResult<IEnumerable<AddressClient>>> GetAddressClients()
        {
            var addressClient = await _addressClientServices.GetAddressClientAsync();

            if (addressClient == null || !addressClient.Any())
            {
                return NotFound();
            }

            return Ok(addressClient);
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Obtém um endereço por ID", Description = "Retorna um endereço de cliente específico com base no ID fornecido.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(AddressClient))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Não encontrado")]
        public async Task<ActionResult<AddressClient>> GetAddressClient(int id)
        {
            var address = await _addressClientServices.GetIdAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPut("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Atualiza um endereço", Description = "Atualiza as informações de um endereço de cliente existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Não encontrado")]
        public async Task<IActionResult> PutAddressClient(int id, BodyAddressClientViewModel address)
        {
            if (address == null || id != address.Id)
            {
                return BadRequest("O ID fornecido na URL não corresponde ao ID de um endereço fornecido.");
            }

            var data = await _addressClientServices.GetIdAsync(id);

            if (data == null)
            {
                return NotFound("Endereço não encontrado.");
            }
            var client = await _clientsServises.GetIdAsync(address.ClientId);
            if (client == null)
            {
                return BadRequest("Não foi possível adicionar o endereço.");
            }
            
            data.Id = address.Id;
            data.Street = address.Street;
            data.Number = address.Number;
            data.Neighborhood = address.Neighborhood;
            data.ZipCode = address.ZipCode.Replace("-", "");
            data.City = address.City;
            data.State = address.State;
            data.Country = address.Country;
            data.Client = client;

            var result = await _addressClientServices.UpdateAsync(data);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetAddressClient), new { id = result.Id }, result);
            }
            else
            {
                return BadRequest("Não foi possível atualizar o endereço.");
            }
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Cria um endereço", Description = "Cria um novo endereço de cliente.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Created", typeof(AddressClient))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        public async Task<ActionResult<AddressClient>> PostAddressClient(BodyAddressClientViewModel address)
        {
            if (address == null)
            {
                return BadRequest("O endereço fornecido é nulo.");
            }
            var client = await _clientsServises.GetIdAsync(address.ClientId);
            if(client == null)
            {
                return BadRequest("Não foi possível adicionar o endereço.");
            }
            var data = new AddressClient();
            data.Id = address.Id;
            data.Street = address.Street;
            data.Number = address.Number;
            data.Neighborhood = address.Neighborhood;
            data.ZipCode = address.ZipCode.Replace("-", "");
            data.City = address.City;
            data.State = address.State;
            data.Country = address.Country;
            data.Client = client;
            var result = await _addressClientServices.AddAsync(data);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetAddressClient), new { id = result.Id }, result);
            }
            else
            {
                return BadRequest("Não foi possível adicionar o endereço.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Exclui um endereço", Description = "Remove um endereço de cliente existente com base no ID fornecido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Não encontrado")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var addressToDelete = await _addressClientServices.GetIdAsync(id);

            if (addressToDelete == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            var isDeleted = await _addressClientServices.DeleteAsync(id);

            if (isDeleted)
            {
                return Ok("Deletado com sucesso");
            }
            else
            {
                return BadRequest("Não foi possível excluir o endereço.");
            }
        }

        private async Task<bool> ClientExists(int id)
        {
            var addressClient = await _addressClientServices.GetAddressClientAsync();
            return addressClient?.Any(e => e.Id == id) ?? false;
        }
    }
}
