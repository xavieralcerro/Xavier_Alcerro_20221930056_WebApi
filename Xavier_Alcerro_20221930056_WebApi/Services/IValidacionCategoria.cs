namespace Xavier_Alcerro_20221930056_WebApi.Services
{
    public interface IValidacionCategoria
    {
        Task<bool> NombreUnicoAsync(string nombre, int? id = null);
        Task<bool> ExisteAsync(int id);
    }
}