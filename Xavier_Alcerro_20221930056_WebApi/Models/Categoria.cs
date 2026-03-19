namespace Xavier_Alcerro_20221930056_WebApi.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public List<Videojuego> Videojuegos { get; set; } = new();
    }
}