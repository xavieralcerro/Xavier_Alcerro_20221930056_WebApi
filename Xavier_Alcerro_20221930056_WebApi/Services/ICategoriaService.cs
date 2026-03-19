using Xavier_Alcerro_20221930056_WebApi.Models;

namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> ObtenerTodasAsync();
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task<Categoria> CrearAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}