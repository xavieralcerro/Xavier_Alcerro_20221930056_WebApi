using Microsoft.AspNetCore.Mvc;
using Xavier_Alcerro_20221930056_WebApi.Models;
using Xavier_Alcerro_20221930056_WebApi.Services;
using Xavier_Alcerro_20221930056_WebApi.Data;
using Xavier_Alcerro_20221930056_WebApi.DTOs;

namespace Xavier_Alcerro_20221930056_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideojuegosController : ControllerBase
    {
        private readonly IVideojuegoService _videojuegoService;

        public VideojuegosController(IVideojuegoService videojuegoService)
        {
            _videojuegoService = videojuegoService;
        }

        // GET: api/videojuegos
        [HttpGet]
        public async Task<ActionResult<List<VideojuegoDTO>>> Get()
        {
            var juegos = await _videojuegoService.ObtenerTodosAsync();

            var resultado = juegos.Select(j => new VideojuegoDTO
            {
                Id = j.Id,
                Nombre = j.Nombre,
                Descripcion = j.Descripcion,
                Categoria = j.Categoria?.Nombre ?? "",
                CategoriaId = j.CategoriaId
            }).ToList();

            return Ok(resultado);
        }

        // GET: api/videojuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideojuegoDTO>> Get(int id)
        {
            var juego = await _videojuegoService.ObtenerPorIdAsync(id);

            if (juego == null)
                return NotFound($"No encontré el videojuego {id}");

            var resultado = new VideojuegoDTO
            {
                Id = juego.Id,
                Nombre = juego.Nombre,
                Descripcion = juego.Descripcion,
                Categoria = juego.Categoria?.Nombre ?? "",
                CategoriaId = juego.CategoriaId
            };

            return Ok(resultado);
        }

        // GET: api/videojuegos/porcategoria/5
        [HttpGet("porcategoria/{categoriaId}")]
        public async Task<ActionResult<List<VideojuegoDTO>>> GetPorCategoria(int categoriaId)
        {
            var juegos = await _videojuegoService.ObtenerPorCategoriaAsync(categoriaId);

            var resultado = juegos.Select(j => new VideojuegoDTO
            {
                Id = j.Id,
                Nombre = j.Nombre,
                Descripcion = j.Descripcion,
                Categoria = j.Categoria?.Nombre ?? "",
                CategoriaId = j.CategoriaId
            }).ToList();

            return Ok(resultado);
        }

        // POST: api/videojuegos
        [HttpPost]
        public async Task<ActionResult<Videojuego>> Post(CrearVideojuegoDTO dto)
        {
            try
            {
                var juego = new Videojuego
                {
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    CategoriaId = dto.CategoriaId
                };

                var nuevo = await _videojuegoService.CrearAsync(juego);
                return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/videojuegos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ActualizarVideojuegoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID de la URL no coincide con el del cuerpo");

            try
            {
                var juego = new Videojuego
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    CategoriaId = dto.CategoriaId,
                    Activo = dto.Activo
                };

                await _videojuegoService.ActualizarAsync(juego);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/videojuegos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _videojuegoService.EliminarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}