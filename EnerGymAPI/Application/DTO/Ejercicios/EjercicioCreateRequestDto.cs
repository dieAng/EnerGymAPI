namespace EnerGymAPI.Application.DTO.Ejercicios
{
    public class EjercicioCreateRequestDto
    {
        public required string Nombre { get; set; }
        public string? GrupoMuscular { get; set; }
        public string? Equipo { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenUrl { get; set; }
        public string? VideoUrl { get; set; }
    }
}