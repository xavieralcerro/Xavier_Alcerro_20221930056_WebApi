using Xavier_Alcerro_20221930056_WebApi.Models;
using Xavier_Alcerro_20221930056_WebApi.Repositories;

namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _categoriaRepo;
        private readonly IValidacionCategoria _validacion;

        public CategoriaService(
            ICategoriaRepositorio categoriaRepo,
            IValidacionCategoria validacion)
        {
            _categoriaRepo = categoriaRepo;
            _validacion = validacion;
        }

        public async Task<List<Categoria>> ObtenerTodasAsync()
        {
            return await _categoriaRepo.ObtenerTodosAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _categoriaRepo.ObtenerConJuegosAsync(id);
        }

        public async Task<Categoria> CrearAsync(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new Exception("La categoría debe tener un nombre");

            if (!await _validacion.NombreUnicoAsync(categoria.Nombre))
                throw new Exception("Ya existe una categoría con ese nombre");

            return await _categoriaRepo.GuardarAsync(categoria);
        }

        public async Task EliminarAsync(int id)
        {
            if (!await _validacion.ExisteAsync(id))
                throw new Exception($"No encontré la categoría {id}");

            if (await _categoriaRepo.TieneJuegosAsync(id))
                throw new Exception("No puedo eliminar: la categoría tiene videojuegos");

            await _categoriaRepo.EliminarAsync(id);
        }
    }
}