using Microsoft.EntityFrameworkCore;
using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Videojuego> Videojuegos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Videojuego>()
                .HasOne(v => v.Categoria)
                .WithMany(c => c.Videojuegos)
                .HasForeignKey(v => v.CategoriaId);

            modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.Activo);
            modelBuilder.Entity<Videojuego>().HasQueryFilter(v => v.Activo);
        }
    }
}