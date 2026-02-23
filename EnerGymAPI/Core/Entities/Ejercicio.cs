namespace EnerGymAPI.Entities;

public class Ejercicio
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; }
    public string GrupoMuscular { get; set; }
    public string Equipo { get; set; }
    public string Descripcion { get; set; }
    public string ImagenUrl { get; set; }
    public string VideoUrl { get; set; }

    public ICollection<RutinaEjercicio> RutinaEjercicios { get; set; }
}