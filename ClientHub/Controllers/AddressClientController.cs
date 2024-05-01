using ClientHub.Models;
using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientHub.Controllers
{
    public class AddressClientController : Controller
    {
        private readonly IAddressClientServices _addressClientsServises;
        private readonly IClientsServises _clientsServises;

        public AddressClientController(IAddressClientServices addressClientsServises, IClientsServises clientsServises)
        {
            _addressClientsServises = addressClientsServises;
            _clientsServises = clientsServises;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _addressClientsServises.GetAddressClientAsync();
            return View(clients);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var addressViewModel = new AddressClientViewModel();

            if (id != null)
            {
                var address = await _addressClientsServises.GetIdAsync((int)id);

                if (address == null)
                {
                    return NotFound();
                }
                addressViewModel = new AddressClientViewModel(address);
                addressViewModel.ClientId = address.Client.Id;
            }

            addressViewModel.Clients = await _clientsServises.GetClientsAsync();

            return View(addressViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AddressClientViewModel address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (address != null)
                    {
                        var data = await _addressClientsServises.GetIdAsync(address.Id);
                        var client = await _clientsServises.GetIdAsync(address.ClientId);
                        if(client == null)
                        {
                            ModelState.AddModelError("", "Ocorreu um erro ao processar a solicitação.");
                        }

                        if (data == null)
                        {
                            data = new AddressClient();
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

                        if (data.Id != 0)
                        {
                            await _addressClientsServises.UpdateAsync(data);
                        }
                        else
                        {
                            await _addressClientsServises.AddAsync(data);
                        }
                        address.Clients = await _clientsServises.GetClientsAsync();
                        address.ClientId = client.Id;
                        TempData["Alert"] = "Cadastrado com sucesso";
                        return View(address);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao processar a solicitação.");
                }
            }

            return View(address);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _addressClientsServises.GetIdAsync(id);

                if (data == null)
                {
                    return RedirectToAction("Index", "AddressClient");
                }

                var result = await _addressClientsServises.DeleteAsync(id);


                return RedirectToAction("Index", "AddressClient");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "AddressClient");
            }
        }
    }
}
