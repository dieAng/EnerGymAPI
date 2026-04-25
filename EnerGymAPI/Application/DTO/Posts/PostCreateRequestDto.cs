using System;

namespace EnerGymAPI.Application.DTO.Posts
{
    public class PostCreateRequestDto
    {
        public Guid UsuarioId { get; set; }
        public string? Contenido { get; set; }
        public string? ImagenUrl { get; set; }
        public double EnergiaGenerada { get; set; }
        public long Fecha { get; set; }
    }
}