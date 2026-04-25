using System;

namespace EnerGymAPI.Application.DTO.Likes
{
    public class LikeRequestDto
    {
        public Guid PostId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}