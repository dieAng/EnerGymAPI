using System.ComponentModel.DataAnnotations;

namespace EnerGymAPI.Application.DTO.Auth
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public required string RefreshToken { get; set; }
    }
}