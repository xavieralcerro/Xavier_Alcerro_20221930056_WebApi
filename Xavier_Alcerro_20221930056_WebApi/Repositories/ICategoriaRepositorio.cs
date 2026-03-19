using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Repositories
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        Task<Categoria?> ObtenerConJuegosAsync(int id);
        Task<bool> TieneJuegosAsync(int id);
    }
}