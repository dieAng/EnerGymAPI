using EnerGymAPI.Application.DTO.RutinaEjercicios;

namespace EnerGymAPI.Application.DTO.Rutinas;

public class RutinaCreateDto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Nivel { get; set; }
    public string Objetivo { get; set; }

    public List<RutinaEjercicioCreateDto> Ejercicios { get; set; }
}