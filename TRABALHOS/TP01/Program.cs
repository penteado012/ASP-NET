using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

//Matheus Penteado CB3031501
//Joao Victor Sinopolli 3032094

namespace TP01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("   TESTE DAS ENTIDADES E METODOS (ITEM C)");
            Console.WriteLine("==================================================\n");

            // 1. Criando multiplos autores
            Author autor1 = new Author("Tan Ah Teck", "ahteck@somewhere.com", 'm');
            Author autor2 = new Author("Paul Tan", "paul@nowhere.com", 'm');
            Author[] autores = new Author[] { autor1, autor2 };

            // 2. Instanciando Book com mais de um autor
            Book livro = new Book("Java for Dummies", autores, 19.99, 99);

            // 3. Testando TODOS os metodos da classe Book:
            Console.WriteLine("1. GetName(): " + livro.getName());

            Console.WriteLine("2. GetAuthors():");
            foreach (var autor in livro.getAuthors())
            {
                Console.WriteLine("   - " + autor.ToString());
            }

            Console.WriteLine("3. GetPrice(): R$ " + livro.getPrice());
            Console.WriteLine("4. GetQty(): " + livro.getQty());
            Console.WriteLine("5. GetAuthorNames(): " + livro.getAuthorNames());
            Console.WriteLine("6. ToString(): " + livro.ToString());

            // Testando os Setters
            Console.WriteLine("\n--- Modificando valores via Setters ---");
            livro.setPrice(29.90);
            livro.setQty(150);
            Console.WriteLine("Novo Preco (SetPrice): R$ " + livro.getPrice());
            Console.WriteLine("Nova Qtd (SetQty): " + livro.getQty());
            Console.WriteLine("Novo ToString(): " + livro.ToString());

            // 4. Teste de integracao com o Repositorio CSV (Item B)
            Console.WriteLine("\n==================================================");
            Console.WriteLine("   TESTE DO REPOSITORIO CSV (ITEM B)");
            Console.WriteLine("==================================================\n");

            BookRepository repo = new BookRepository("livros.csv");

            // Salva o livro testado
            repo.SaveAll(new List<Book> { livro });
            Console.WriteLine("Livro salvo com sucesso no arquivo CSV!");

            // Le de volta do CSV
            List<Book> livrosDoArquivo = repo.GetAll();
            Console.WriteLine($"\nTotal de livros lidos do CSV: {livrosDoArquivo.Count}");
            foreach (var b in livrosDoArquivo)
            {
                Console.WriteLine("-> " + b.ToString());
            }

            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}