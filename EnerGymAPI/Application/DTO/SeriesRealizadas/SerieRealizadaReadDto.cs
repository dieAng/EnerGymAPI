namespace EnerGymAPI.Application.DTO.SeriesRealizadas;

public class SerieRealizadaReadDto
{
    public Guid Id { get; set; }
    public Guid EjercicioId { get; set; }
    public int Repeticiones { get; set; }
    public float Peso { get; set; }
}