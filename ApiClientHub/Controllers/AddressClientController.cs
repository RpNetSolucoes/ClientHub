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
        [SwaggerOperation(Summary = "Obt�m todos os endere�os de clientes", Description = "Retorna uma lista de todos os endere�os de clientes cadastrados.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(IEnumerable<AddressClient>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
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
        [SwaggerOperation(Summary = "Obt�m um endere�o por ID", Description = "Retorna um endere�o de cliente espec�fico com base no ID fornecido.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(AddressClient))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
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
        [SwaggerOperation(Summary = "Atualiza um endere�o", Description = "Atualiza as informa��es de um endere�o de cliente existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<IActionResult> PutAddressClient(int id, BodyAddressClientViewModel address)
        {
            if (address == null || id != address.Id)
            {
                return BadRequest("O ID fornecido na URL n�o corresponde ao ID de um endere�o fornecido.");
            }

            var data = await _addressClientServices.GetIdAsync(id);

            if (data == null)
            {
                return NotFound("Endere�o n�o encontrado.");
            }
            var client = await _clientsServises.GetIdAsync(address.ClientId);
            if (client == null)
            {
                return BadRequest("N�o foi poss�vel adicionar o endere�o.");
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
                return BadRequest("N�o foi poss�vel atualizar o endere�o.");
            }
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Cria um endere�o", Description = "Cria um novo endere�o de cliente.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Created", typeof(AddressClient))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        public async Task<ActionResult<AddressClient>> PostAddressClient(BodyAddressClientViewModel address)
        {
            if (address == null)
            {
                return BadRequest("O endere�o fornecido � nulo.");
            }
            var client = await _clientsServises.GetIdAsync(address.ClientId);
            if(client == null)
            {
                return BadRequest("N�o foi poss�vel adicionar o endere�o.");
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
                return BadRequest("N�o foi poss�vel adicionar o endere�o.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Exclui um endere�o", Description = "Remove um endere�o de cliente existente com base no ID fornecido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var addressToDelete = await _addressClientServices.GetIdAsync(id);

            if (addressToDelete == null)
            {
                return NotFound("Endere�o n�o encontrado.");
            }

            var isDeleted = await _addressClientServices.DeleteAsync(id);

            if (isDeleted)
            {
                return Ok("Deletado com sucesso");
            }
            else
            {
                return BadRequest("N�o foi poss�vel excluir o endere�o.");
            }
        }

        private async Task<bool> ClientExists(int id)
        {
            var addressClient = await _addressClientServices.GetAddressClientAsync();
            return addressClient?.Any(e => e.Id == id) ?? false;
        }
    }
}
