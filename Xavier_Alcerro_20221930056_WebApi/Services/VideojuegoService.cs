using Xavier_Alcerro_20221930056_WebApi.Models;
using Xavier_Alcerro_20221930056_WebApi.Repositories;

namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public class VideojuegoService : IVideojuegoService
    {
        private readonly IVideojuegoRepositorio _videojuegoRepo;
        private readonly IValidacionVideojuego _validacion;

        public VideojuegoService(
            IVideojuegoRepositorio videojuegoRepo,
            IValidacionVideojuego validacion)
        {
            _videojuegoRepo = videojuegoRepo;
            _validacion = validacion;
        }

        public async Task<List<Videojuego>> ObtenerTodosAsync()
        {
            return await _videojuegoRepo.ObtenerTodosAsync();
        }

        public async Task<Videojuego?> ObtenerPorIdAsync(int id)
        {
            return await _videojuegoRepo.ObtenerConCategoriaAsync(id);
        }

        public async Task<Videojuego> CrearAsync(Videojuego videojuego)
        {
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
                throw new Exception("El videojuego debe tener un nombre");

            if (!await _validacion.CategoriaValidaAsync(videojuego.CategoriaId))
                throw new Exception("La categoría no existe");

            if (!await _validacion.NombreUnicoEnCategoriaAsync(
                videojuego.Nombre, videojuego.CategoriaId))
                throw new Exception("Ya hay un juego con ese nombre en esta categoría");

            return await _videojuegoRepo.GuardarAsync(videojuego);
        }

        public async Task ActualizarAsync(Videojuego videojuego)
        {
            if (!await _validacion.ExisteAsync(videojuego.Id))
                throw new Exception($"No encontré el videojuego {videojuego.Id}");

            if (!await _validacion.CategoriaValidaAsync(videojuego.CategoriaId))
                throw new Exception("La categoría no existe");

            if (!await _validacion.NombreUnicoEnCategoriaAsync(
                videojuego.Nombre, videojuego.CategoriaId, videojuego.Id))
                throw new Exception("Ya hay otro juego con ese nombre en esta categoría");

            await _videojuegoRepo.ActualizarAsync(videojuego);
        }

        public async Task EliminarAsync(int id)
        {
            if (!await _validacion.ExisteAsync(id))
                throw new Exception($"No encontré el videojuego {id}");

            await _videojuegoRepo.EliminarAsync(id);
        }

        public async Task<List<Videojuego>> ObtenerPorCategoriaAsync(int categoriaId)
        {
            return await _videojuegoRepo.ObtenerPorCategoriaAsync(categoriaId);
        }
    }
}