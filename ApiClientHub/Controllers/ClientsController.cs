using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientHub.Models;
using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiClientHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsServises _clientsServises;

        public ClientsController(IClientsServises clientsServises)
        {
            _clientsServises = clientsServises;
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Obt�m todos os clientes", Description = "Retorna uma lista de todos os clientes cadastrados.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(IEnumerable<Clients>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
        {
            var clients = await _clientsServises.GetClientsAsync();

            if (clients == null || clients.Count == 0)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Obt�m um cliente por ID", Description = "Retorna um cliente espec�fico com base no ID fornecido.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(Clients))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<ActionResult<Clients>> GetClient(int id)
        {
            var client = await _clientsServises.GetIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Atualiza um cliente", Description = "Atualiza as informa��es de um cliente existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<IActionResult> PutClient(int id, BodyClientViewModel client)
        {
            if (client == null || id != client.Id)
            {
                return BadRequest("O ID fornecido na URL n�o corresponde ao ID do cliente fornecido.");
            }

            var data = await _clientsServises.GetIdAsync(id);

            if (data == null)
            {
                return NotFound("Cliente n�o encontrado.");
            }
            data.Id = client.Id;
            data.Name = client.Name;
            data.Email = client.Email;
            data.LogoType = client.LogoType;

            var result = await _clientsServises.UpdateAsync(data);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetClient), new { id = result.Id }, result);
            }
            else
            {
                return BadRequest("N�o foi poss�vel atualizar o cliente.");
            }
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Cria um cliente", Description = "Cria um novo cliente.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Created", typeof(Clients))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        public async Task<ActionResult<Clients>> PostClient(BodyClientViewModel client)
        {
            if (client == null)
            {
                return BadRequest("O cliente fornecido � nulo.");
            }
            Clients emailExist = await _clientsServises.GetEmailAsync(client.Email);
            if (emailExist != null)
            {
                return BadRequest("O email fornecido j� existe.");
            }
            var data = new Clients();
            data.Id = client.Id;
            data.Name = client.Name;
            data.Email = client.Email;
            data.LogoType = client.LogoType;

            var result = await _clientsServises.AddAsync(data);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetClient), new { id = result.Id }, result);
            }
            else
            {
                return BadRequest("N�o foi poss�vel adicionar o cliente.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Exclui um cliente", Description = "Remove um cliente existente com base no ID fornecido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var addressToDelete = await _clientsServises.GetIdAsync(id);

            if (addressToDelete == null)
            {
                return NotFound("Cliente n�o encontrado.");
            }

            var isDeleted = await _clientsServises.DeleteAsync(id);

            if (isDeleted)
            {
                return Ok("Deletado com sucesso");
            }
            else
            {
                return BadRequest("N�o foi poss�vel excluir o cliente.");
            }
        }

        [HttpGet("email/{email}")]
        [Authorize]
        [SwaggerOperation(Summary = "Verifica a exist�ncia de um email", Description = "Verifica se um email de cliente j� est� em uso.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "N�o encontrado")]
        public async Task<IActionResult> EmailExists(string email)
        {
            var emailExists = await _clientsServises.GetEmailAsync(email);

            if (emailExists == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emailExists);
            }
        }

        private async Task<bool> ClientExistsAsync(int id)
        {
            var clients = await _clientsServises.GetClientsAsync();
            return clients?.Any(e => e.Id == id) ?? false;
        }
    }
}
