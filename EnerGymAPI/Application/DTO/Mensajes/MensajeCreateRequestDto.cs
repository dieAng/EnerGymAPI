using System;

namespace EnerGymAPI.Application.DTO.Mensajes
{
    public class MensajeCreateRequestDto
    {
        public Guid EmisorId { get; set; }
        public Guid ReceptorId { get; set; }
        public required string Contenido { get; set; }
        public long Fecha { get; set; }
    }
}