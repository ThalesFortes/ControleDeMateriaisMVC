using ControleDeMateriaisMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleDeMateriaisMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _api = "https://localhost:44337/".Trim();
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, string api, HttpClient httpClient)
        {
            _logger = logger;
            _api = api;
            _httpClient = httpClient;
        }

        //public async Task< IActionResult>Index()
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync("/listaEstoque");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var listaEstoque = await response.Content.ReadFromJsonAsync<List<Estoque>>();
        //            return listaEstoque;
        //        }
        //        else
        //        {
        //            return StatusCode((int)response.StatusCode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Em caso de erro, lança a exceção
        //        throw ex;
        //    }
        //}

        //POST
        //public async Task<IActionResult> CADASTRO(ESTOQUE estoque)
        //{
        //    try
        //    {
        //        // Faz a requisição POST para o endpoint /cadastraEstoque
        //        var response = await _httpClient.PostAsJsonAsync("/cadastraEstoque", estoque);

        //        // Se a resposta for bem sucedida (200 OK)
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Lê o conteúdo da resposta (que deve ser um booleano indicando sucesso)
        //            var resultado = await response.Content.ReadFromJsonAsync<bool>();
        //            return resultado;
        //        }
        //        else
        //        {
        //            // Se a resposta não for bem sucedida, retorna false
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Em caso de erro, lança a exceção
        //        throw ex;
        //    }
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
