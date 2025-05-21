using Microsoft.EntityFrameworkCore;
using ProdutosModel;

namespace ProdutosData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoModel>()
                .Property(p => p.Preco)
                .HasPrecision(18, 2); // 18 dígitos no total, 2 casas decimais

            base.OnModelCreating(modelBuilder);
        }
    }
}