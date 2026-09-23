using Microsoft.EntityFrameworkCore;
using SistemaBLContainer.Models;
using TP02.Models;

namespace TP02.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BL> BLs { get; set; }
        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Container>()
                .HasOne(c => c.BL)
                .WithMany(b => b.Containers)
                .HasForeignKey(c => c.BLId)
                .IsRequired();
        }
    }
}