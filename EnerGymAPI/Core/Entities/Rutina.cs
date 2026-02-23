namespace EnerGymAPI.Entities;

public class Rutina
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UsuarioId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Nivel { get; set; }
    public string Objetivo { get; set; }
    public bool EsPredisenada { get; set; }

    public Usuario Usuario { get; set; }
    public ICollection<RutinaEjercicio> RutinaEjercicios { get; set; }
}