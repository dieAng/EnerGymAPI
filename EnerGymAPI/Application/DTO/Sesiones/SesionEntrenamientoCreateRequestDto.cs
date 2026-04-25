using System;

namespace EnerGymAPI.Application.DTO.Sesiones
{
    public class SesionEntrenamientoCreateRequestDto
    {
        public Guid UsuarioId { get; set; }
        public Guid? RutinaId { get; set; }
        public long Fecha { get; set; }
        public int? DuracionSegundos { get; set; }
        public int? EnergiaGeneradaWh { get; set; }
        public int? CaloriasQuemadas { get; set; }
    }
}