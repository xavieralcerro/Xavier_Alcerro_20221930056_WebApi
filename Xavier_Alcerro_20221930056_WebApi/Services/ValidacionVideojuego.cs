using Xavier_Alcerro_20221930056_WebApi.Repositories;

namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public class ValidacionVideojuego : IValidacionVideojuego
    {
        private readonly IVideojuegoRepositorio _videojuegoRepo;
        private readonly ICategoriaRepositorio _categoriaRepo;

        public ValidacionVideojuego(
            IVideojuegoRepositorio videojuegoRepo,
            ICategoriaRepositorio categoriaRepo)
        {
            _videojuegoRepo = videojuegoRepo;
            _categoriaRepo = categoriaRepo;
        }

        public async Task<bool> NombreUnicoEnCategoriaAsync(string nombre, int categoriaId, int? id = null)
        {
            var juegos = await _videojuegoRepo.ObtenerPorCategoriaAsync(categoriaId);
            return !juegos.Any(j =>
                j.Nombre.ToLower() == nombre.ToLower() &&
                (!id.HasValue || j.Id != id.Value));
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _videojuegoRepo.ObtenerPorIdAsync(id) != null;
        }

        public async Task<bool> CategoriaValidaAsync(int categoriaId)
        {
            return await _categoriaRepo.ObtenerPorIdAsync(categoriaId) != null;
        }
    }
}