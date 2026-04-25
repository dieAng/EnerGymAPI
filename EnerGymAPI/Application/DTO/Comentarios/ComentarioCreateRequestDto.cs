using System;

namespace EnerGymAPI.Application.DTO.Comentarios
{
    public class ComentarioCreateRequestDto
    {
        public Guid PostId { get; set; }
        public Guid UsuarioId { get; set; }
        public required string Contenido { get; set; }
        public long Fecha { get; set; }
    }
}