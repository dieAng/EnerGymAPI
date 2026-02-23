namespace EnerGymAPI.Entities;

public class SesionEntrenamiento
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UsuarioId { get; set; }
    public Guid? RutinaId { get; set; }
    public DateTime Fecha { get; set; }

    public Usuario Usuario { get; set; }
    public Rutina Rutina { get; set; }
    public ICollection<SerieRealizada> Series { get; set; }
}