namespace EnerGymAPI.Application.DTO.RutinaEjercicios;

public class RutinaEjercicioReadDto
{
    public Guid EjercicioId { get; set; }
    public string NombreEjercicio { get; set; }
    public int Series { get; set; }
    public int Repeticiones { get; set; }
    public float? PesoObjetivo { get; set; }
    public int? DescansoSeg { get; set; }
    public int Orden { get; set; }
}