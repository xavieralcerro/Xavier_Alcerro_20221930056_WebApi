using Microsoft.EntityFrameworkCore;
using Xavier_Alcerro_20221930056_WebApi.Data;
using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Repositories
{
    public class VideojuegoRepositorio : RepositorioBase<Videojuego>, IVideojuegoRepositorio
    {
        public VideojuegoRepositorio(AppDbContext context) : base(context) { }

        public async Task<List<Videojuego>> ObtenerPorCategoriaAsync(int categoriaId)
        {
            return await _context.Videojuegos
                .Where(v => v.CategoriaId == categoriaId)
                .Include(v => v.Categoria)
                .ToListAsync();
        }

        public async Task<Videojuego?> ObtenerConCategoriaAsync(int id)
        {
            return await _context.Videojuegos
                .Include(v => v.Categoria)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}