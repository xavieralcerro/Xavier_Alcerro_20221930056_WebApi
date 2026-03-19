using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public interface IVideojuegoService
    {
        Task<List<Videojuego>> ObtenerTodosAsync();
        Task<Videojuego?> ObtenerPorIdAsync(int id);
        Task<Videojuego> CrearAsync(Videojuego videojuego);
        Task ActualizarAsync(Videojuego videojuego);
        Task EliminarAsync(int id);
        Task<List<Videojuego>> ObtenerPorCategoriaAsync(int categoriaId);
    }
}