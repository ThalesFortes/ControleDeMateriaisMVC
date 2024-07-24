using ControleDeMateriaisAPI.Models;
using ControleDeMateriaisMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ControleDeMateriaisMVC.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "https://localhost:44337"; 

        public EstoqueController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/listaEstoque");

            if (response.IsSuccessStatusCode)
            {
                var listaEstoque = await response.Content.ReadFromJsonAsync<List<EstoqueViewModel>>();
                return View(listaEstoque);
            }
            else
            {
                return Problem(statusCode: (int)response.StatusCode, title: "Error fetching stock items");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(Estoque estoque)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var serializedEstoque = JsonSerializer.Serialize(estoque);
                var content = new StringContent(serializedEstoque, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{_apiBaseUrl}/cadastraEstoque", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Problem(statusCode: (int)response.StatusCode, title: "Error creating stock item");
                }
            }
            catch (Exception ex)
            {
                return Problem(title: "Unexpected error creating stock item", detail: ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}//buscaEstoque/{id}");

            if (response.IsSuccessStatusCode)
            {
                var estoque = await response.Content.ReadFromJsonAsync<EstoqueViewModel>();
                if (estoque != null)
                {
                    return View(estoque);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return Problem(statusCode: (int)response.StatusCode, title: "Error fetching stock item details");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Estoque estoque)
        {
            try
            {
                if (id != estoque.IdEstoque)
                {
                    return BadRequest("ID mismatch in request");
                }

                var client = _httpClientFactory.CreateClient();
                var serializedEstoque = JsonSerializer.Serialize(estoque);
                var content = new StringContent(serializedEstoque, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{_apiBaseUrl}/atualizarEstoque/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Problem(statusCode: (int)response.StatusCode, title: "Error updating stock item");
                }
            }
            catch (Exception ex)
            {
                return Problem(title: "Unexpected error updating stock item", detail: ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiBaseUrl}/deletarEstoque/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Problem(statusCode: (int)response.StatusCode, title: "Error deleting stock item");
            }
        }
    }
}
