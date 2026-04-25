using System;

namespace EnerGymAPI.Application.DTO.Auth
{
    public class LoginResponseDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public Guid UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public required string Rol { get; set; }
    }
}