using EnerGymAPI.Application.DTO.RutinaEjercicios;

namespace EnerGymAPI.Application.DTO.Rutinas;

public class RutinaReadDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Nivel { get; set; }
    public string Objetivo { get; set; }
    public bool EsPredisenada { get; set; }

    public List<RutinaEjercicioReadDto> Ejercicios { get; set; }
}