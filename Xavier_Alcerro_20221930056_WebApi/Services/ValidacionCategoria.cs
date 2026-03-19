using Xavier_Alcerro_20221930056_WebApi.Repositories;

namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public class ValidacionCategoria : IValidacionCategoria
    {
        private readonly ICategoriaRepositorio _categoriaRepo;

        public ValidacionCategoria(ICategoriaRepositorio categoriaRepo)
        {
            _categoriaRepo = categoriaRepo;
        }

        public async Task<bool> NombreUnicoAsync(string nombre, int? id = null)
        {
            var categorias = await _categoriaRepo.ObtenerTodosAsync();
            return !categorias.Any(c =>
                c.Nombre.ToLower() == nombre.ToLower() &&
                (!id.HasValue || c.Id != id.Value));
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _categoriaRepo.ObtenerPorIdAsync(id) != null;
        }
    }
}