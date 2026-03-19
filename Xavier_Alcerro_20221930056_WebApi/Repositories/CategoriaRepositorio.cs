using Microsoft.EntityFrameworkCore;
using Xavier_Alcerro_20221930056_WebApi.Data;
using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Repositories
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(AppDbContext context) : base(context) { }

        public async Task<Categoria?> ObtenerConJuegosAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.Videojuegos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> TieneJuegosAsync(int id)
        {
            return await _context.Videojuegos.AnyAsync(v => v.CategoriaId == id);
        }
    }
}