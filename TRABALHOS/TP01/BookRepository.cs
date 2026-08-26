using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

//Matheus Penteado CB3031501
//Joao Victor Sinopolli 3032094

namespace TP01
{
    internal class BookRepository
    {
        private readonly string _filePath;

        internal BookRepository(string filePath = "livros.csv")
        {
            _filePath = filePath;
        }

        // Salvar uma lista de livros no CSV
        internal void SaveAll(List<Book> books)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                foreach (var book in books)
                {
                    List<string> authorsSerialized = new List<string>();
                    foreach (var author in book.getAuthors())
                    {
                        authorsSerialized.Add($"{author.GetName()}|{author.GetEmail()}|{author.GetGender()}");
                    }
                    string authorsField = string.Join("#", authorsSerialized);

                    string line = $"{book.getName()};{book.getPrice().ToString(CultureInfo.InvariantCulture)};{book.getQty()};{authorsField}";
                    sw.WriteLine(line);
                }
            }
        }

        // Ler os livros do CSV
        internal List<Book> GetAll()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(_filePath))
                return books;

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(';');
                if (parts.Length < 4) continue;

                string name = parts[0];
                double price = double.Parse(parts[1], CultureInfo.InvariantCulture);
                int qty = int.Parse(parts[2]);

                string[] authorsParts = parts[3].Split('#');
                Author[] authors = new Author[authorsParts.Length];

                for (int i = 0; i < authorsParts.Length; i++)
                {
                    string[] authorData = authorsParts[i].Split('|');
                    string authorName = authorData[0];
                    string authorEmail = authorData[1];
                    char authorGender = authorData[2][0];

                    authors[i] = new Author(authorName, authorEmail, authorGender);
                }

                books.Add(new Book(name, authors, price, qty));
            }

            return books;
        }
    }
}