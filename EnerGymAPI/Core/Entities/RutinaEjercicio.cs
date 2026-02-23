namespace EnerGymAPI.Entities;

public class RutinaEjercicio
{
    public Guid RutinaId { get; set; }
    public Guid EjercicioId { get; set; }

    public int Series { get; set; }
    public int Repeticiones { get; set; }
    public float? PesoObjetivo { get; set; }
    public int? DescansoSeg { get; set; }
    public int Orden { get; set; }

    public Rutina Rutina { get; set; }
    public Ejercicio Ejercicio { get; set; }
}