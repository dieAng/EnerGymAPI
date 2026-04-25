using System;

namespace EnerGymAPI.Application.DTO.Mensajes
{
    public class MensajeResponseDto
    {
        public Guid Id { get; set; }
        public Guid EmisorId { get; set; }
        public Guid ReceptorId { get; set; }
        public required string Contenido { get; set; }
        public long Fecha { get; set; }
    }
}