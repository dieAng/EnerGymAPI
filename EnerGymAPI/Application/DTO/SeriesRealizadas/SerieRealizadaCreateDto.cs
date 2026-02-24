namespace EnerGymAPI.Application.DTO.SeriesRealizadas;

public class SerieRealizadaCreateDto
{
    public Guid EjercicioId { get; set; }
    public int Repeticiones { get; set; }
    public float Peso { get; set; }
}