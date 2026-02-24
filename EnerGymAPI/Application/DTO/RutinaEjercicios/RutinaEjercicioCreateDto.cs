namespace EnerGymAPI.Application.DTO.RutinaEjercicios;

public class RutinaEjercicioCreateDto
{
    public Guid EjercicioId { get; set; }
    public int Series { get; set; }
    public int Repeticiones { get; set; }
    public float? PesoObjetivo { get; set; }
    public int? DescansoSeg { get; set; }
    public int Orden { get; set; }
}