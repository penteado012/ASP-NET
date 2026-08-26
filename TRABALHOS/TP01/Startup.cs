using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
//Matheus Penteado CB3031501
//Joao Victor Sinopolli 3032094


namespace TP01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Nome/Livro", Mostrar);
            builder.MapRoute("Nome/Autor", NomeLivro);
            builder.MapRoute("NomeAutor/Livro", NomeAutor);
            builder.MapRoute("Livro/ApresentarLivro", ApresentarLivro);
            var rotas = builder.Build();

            app.UseRouter(rotas);
        }

        public async Task Mostrar(HttpContext context)
        {
            var repo = new BookRepository("livros.csv");
            var livro = repo.GetAll().FirstOrDefault();

            if (livro == null)
            {
                await context.Response.WriteAsync("Nenhum livro encontrado.");
                return;
            }

            await context.Response.WriteAsync(livro.getName());
        }

        public async Task NomeLivro(HttpContext context)
        {
            var repo = new BookRepository("livros.csv");
            var livro = repo.GetAll().FirstOrDefault();

            if (livro == null)
            {
                await context.Response.WriteAsync("Nenhum livro encontrado.");
                return;
            }

            await context.Response.WriteAsync(livro.ToString());
        }

        public async Task NomeAutor(HttpContext context)
        {
            var repo = new BookRepository("livros.csv");
            var livro = repo.GetAll().FirstOrDefault();

            if (livro == null)
            {
                await context.Response.WriteAsync("Nenhum autor encontrado.");
                return;
            }

            await context.Response.WriteAsync(livro.getAuthorNames());
        }

        public async Task ApresentarLivro(HttpContext context)
        {
            var repo = new BookRepository("livros.csv");
            var livros = repo.GetAll();

            context.Response.ContentType = "text/html; charset=utf-8";

            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html><html><head><meta charset='utf-8'><title>Apresentar Livro</title></head><body>");

            if (livros.Count == 0)
            {
                html.Append("<h2>Nenhum livro cadastrado no CSV.</h2>");
            }
            else
            {
                foreach (var livro in livros)
                {
                    html.Append($"<h1>Livro: {livro.getName()}</h1>");
                    html.Append("<h3>Autores:</h3><ul>");
                    foreach (var autor in livro.getAuthors())
                    {
                        html.Append($"<li>{autor.GetName()} ({autor.GetEmail()})</li>");
                    }
                    html.Append("</ul><hr>");
                }
            }

            html.Append("</body></html>");

            await context.Response.WriteAsync(html.ToString());
        }
    }
}