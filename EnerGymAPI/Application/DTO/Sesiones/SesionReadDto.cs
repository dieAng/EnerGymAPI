using EnerGymAPI.Application.DTO.SeriesRealizadas;

namespace EnerGymAPI.Application.DTO.Sesiones;

public class SesionReadDto
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public Guid RutinaId { get; set; }

    public List<SerieRealizadaReadDto> Series { get; set; }
}