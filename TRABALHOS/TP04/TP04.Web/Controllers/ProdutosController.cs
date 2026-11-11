using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using TP04.Dominio;

//Dupla: Matheus Penteado de Barros Pantojo e Joao Victor Sinopolli

namespace TP04.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly string _apiBaseUrl;

        public ProdutosController(IConfiguration configuration)
        {
            _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value ?? string.Empty;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            List<Produto> produtos = new List<Produto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_apiBaseUrl}Produtos"))
                {
                    if (response.IsSuccessStatusCode)
                        produtos = await response.Content.ReadFromJsonAsync<List<Produto>>() ?? new List<Produto>();
                }
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}Produtos", produto);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                }
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Produto produto = new Produto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_apiBaseUrl}Produtos/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                        produto = await response.Content.ReadFromJsonAsync<Produto>() ?? new Produto();
                    else
                        return NotFound();
                }
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PutAsJsonAsync($"{_apiBaseUrl}Produtos/{id}", produto);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                }
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Produto produto = new Produto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_apiBaseUrl}Produtos/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                        produto = await response.Content.ReadFromJsonAsync<Produto>() ?? new Produto();
                    else
                        return NotFound();
                }
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"{_apiBaseUrl}Produtos/{id}");
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}