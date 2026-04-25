using System.ComponentModel.DataAnnotations;

namespace EnerGymAPI.Application.DTO.Usuarios
{
    public class UsuarioCreateRequestDto
    {
        [Required]
        public required string Nombre { get; set; }
        
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
        
        public int? Edad { get; set; }
        public float? Peso { get; set; }
        public float? Altura { get; set; }
        public string? Objetivo { get; set; }
        public string? FotoUrl { get; set; }
    }
}
