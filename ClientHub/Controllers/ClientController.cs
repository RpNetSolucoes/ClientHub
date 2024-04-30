using ClientHub.Models;
using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientHub.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientsServises _clientsServises;

        public ClientController(IClientsServises clientsServises)
        {
            _clientsServises = clientsServises;
        }

        public byte[] ConvertFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public IFormFile ConvertByteArrayToFormFile(byte[] fileBytes, string fileName, string contentType)
        {
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                var formFile = new FormFile(memoryStream, 0, fileBytes.Length, null, fileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = contentType
                };

                return formFile;
            }
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientsServises.GetClientsAsync();

            if (clients == null || !clients.Any())
            {
                return View(new List<Clients>());
            }

            foreach (var client in clients)
            {
                client.Logofile = ConvertByteArrayToFormFile(client.LogoType, "nome_do_arquivo.png", "tipo_de_conteudo/mime");
            }

            return View(clients);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                return View(new ClientViewModel());
            }

            var clients = await _clientsServises.GetIdAsync((int)id);

            if (clients == null)
            {
                return NotFound();
            }

            string fileName = "nome_do_arquivo.png";
            string contentType = "tipo_de_conteudo/mime";

            IFormFile formFile = ConvertByteArrayToFormFile(clients.LogoType, fileName, contentType);

            var result = new ClientViewModel(clients, formFile);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (client != null)
                    {
                        var data = await _clientsServises.GetIdAsync(client.Id);
                        var validationEmail = await _clientsServises.GetEmailAsync(client.Email);

                        if (data == null)
                        {
                            data = new Clients();
                        }

                        if (validationEmail != null && client.Id == 0)
                        {
                            ModelState.AddModelError("Email", "Este e-mail já está em uso.");
                            return View(client);
                        }

                        data.Id = client.Id;
                        data.Name = client.Name;
                        data.Email = client.Email;
                        data.LogoType = ConvertFileToByteArray(client.LogoType);

                        if (data.Id != 0)
                        {
                            await _clientsServises.UpdateAsync(data);
                        }
                        else
                        {
                            await _clientsServises.AddAsync(data);
                        }

                        TempData["Alert"] = "Cadastrado com sucesso";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao processar a solicitação.");
                }
            }

            return View(client);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _clientsServises.GetIdAsync(id);

                if (data == null)
                {
                    return RedirectToAction("Index", "Client");
                }

                var result = await _clientsServises.DeleteAsync(id);

               
                return RedirectToAction("Index", "Client");
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Client");
            }
        }
    }
}
