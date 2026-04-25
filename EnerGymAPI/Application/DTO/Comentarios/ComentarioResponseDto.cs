using System;

namespace EnerGymAPI.Application.DTO.Comentarios
{
    public class ComentarioResponseDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UsuarioId { get; set; }
        public required string Contenido { get; set; }
        public long Fecha { get; set; }
    }
}