using Microsoft.EntityFrameworkCore;
using SistemaProdutos.Models;

namespace SistemaProdutos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}