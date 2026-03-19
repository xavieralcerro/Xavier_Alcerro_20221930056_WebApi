namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public interface IValidacionVideojuego
    {
        Task<bool> NombreUnicoEnCategoriaAsync(string nombre, int categoriaId, int? id = null);
        Task<bool> ExisteAsync(int id);
        Task<bool> CategoriaValidaAsync(int categoriaId);
    }
}