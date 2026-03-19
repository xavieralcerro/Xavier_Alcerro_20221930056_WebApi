using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Repositories
{
    public interface IVideojuegoRepositorio : IRepositorio<Videojuego>
    {
        Task<List<Videojuego>> ObtenerPorCategoriaAsync(int categoriaId);
        Task<Videojuego?> ObtenerConCategoriaAsync(int id);
    }
}