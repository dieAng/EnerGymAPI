namespace EnerGymAPI.Application.DTO.Usuarios
{
    public class UsuarioUpdateRequestDto
    {
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public float? Peso { get; set; }
        public float? Altura { get; set; }
        public string? Objetivo { get; set; }
        public string? FotoUrl { get; set; }
    }
}