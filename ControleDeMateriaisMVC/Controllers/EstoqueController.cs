using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisMVC
{
    public class EstoqueController : Controller
    {
        private readonly ControleDeMateriaisContext _context;
        private readonly string _apiBaseUrl = "https://localhost:44337";

        public EstoqueController(ControleDeMateriaisContext context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                // Obter lista de Estoques da API
                var response = await client.GetAsync($"{_apiBaseUrl}/listaEstoque");
                if (response.IsSuccessStatusCode)
                {
                    var listaEstoque = await response.Content.ReadFromJsonAsync<List<Estoque>>();
                    return View(listaEstoque);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                // Obter detalhes do estoque da API
                var response = await client.GetAsync($"{_apiBaseUrl}/estoque/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var estoque = await response.Content.ReadFromJsonAsync<Estoque>();
                    return View(estoque);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstoque,Quantidade,DataCadastro,NotaFiscal,IdProduto")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    // Criar novo estoque na API
                    var response = await client.PostAsJsonAsync($"{_apiBaseUrl}/cadastraEstoque", estoque);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode);
                    }
                }
            }
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", estoque.IdProduto);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                // Obter estoque da API para edição
                var response = await client.GetAsync($"{_apiBaseUrl}/estoque/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var estoque = await response.Content.ReadFromJsonAsync<Estoque>();
                    ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", estoque.IdProduto);
                    return View(estoque);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstoque,Quantidade,DataCadastro,NotaFiscal,IdProduto")] Estoque estoque)
        {
            if (id != estoque.IdEstoque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    // Editar estoque na API
                    var response = await client.PutAsJsonAsync($"{_apiBaseUrl}/estoque/{id}", estoque);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode);
                    }
                }
            }
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", estoque.IdProduto);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                // Obter estoque da API para exclusão
                var response = await client.GetAsync($"{_apiBaseUrl}/estoque/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var estoque = await response.Content.ReadFromJsonAsync<Estoque>();
                    return View(estoque);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                // Excluir estoque na API
                var response = await client.DeleteAsync($"{_apiBaseUrl}/estoque/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoques.Any(e => e.IdEstoque == id);
        }
    }
}