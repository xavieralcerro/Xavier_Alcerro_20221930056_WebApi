namespace Xavier_Alcerro_20221930056_WebApi.Models
{
    public class Videojuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public bool Activo { get; set; } = true;
        public Categoria? Categoria { get; set; }
    }
}
