namespace EnerGymAPI.Entities;

public class SerieRealizada
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SesionId { get; set; }
    public Guid EjercicioId { get; set; }
    public int Repeticiones { get; set; }
    public float Peso { get; set; }

    public SesionEntrenamiento Sesion { get; set; }
    public Ejercicio Ejercicio { get; set; }
}