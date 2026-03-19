using Microsoft.AspNetCore.Mvc;
using Xavier_Alcerro_20221930056_WebApi.Models;
using Xavier_Alcerro_20221930056_WebApi.Services;
using Xavier_Alcerro_20221930056_WebApi.DTOs;

namespace Xavier_Alcerro_20221930056_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<List<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.ObtenerTodasAsync();

            var resultado = categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                TotalJuegos = c.Videojuegos?.Count ?? 0
            }).ToList();

            return Ok(resultado);
        }

        // GET: api/categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _categoriaService.ObtenerPorIdAsync(id);

            if (categoria == null)
                return NotFound($"No encontré la categoría {id}");

            var resultado = new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                TotalJuegos = categoria.Videojuegos?.Count ?? 0
            };

            return Ok(resultado);
        }

        // POST: api/categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(CrearCategoriaDTO dto)
        {
            try
            {
                var categoria = new Categoria { Nombre = dto.Nombre };
                var nueva = await _categoriaService.CrearAsync(categoria);
                return CreatedAtAction(nameof(Get), new { id = nueva.Id }, nueva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoriaService.EliminarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}