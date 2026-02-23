namespace EnerGymAPI.Entities;

public class Receta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UsuarioId { get; set; }
    public string Nombre { get; set; }
    public int? TiempoPreparacion { get; set; }
    public string Alergenos { get; set; }
    public string ImagenUrl { get; set; }
    public string Descripcion { get; set; }
    public bool EsPredisenada { get; set; }

    public Usuario Usuario { get; set; }
    public ICollection<Ingrediente> Ingredientes { get; set; }
}