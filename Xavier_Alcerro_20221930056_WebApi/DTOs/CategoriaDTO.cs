namespace Xavier_Alcerro_20221930056_WebApi.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int TotalJuegos { get; set; }
    }

    public class CrearCategoriaDTO
    {
        public string Nombre { get; set; } = string.Empty;
    }
}