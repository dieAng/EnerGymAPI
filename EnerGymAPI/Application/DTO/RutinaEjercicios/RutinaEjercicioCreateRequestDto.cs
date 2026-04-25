using System;

namespace EnerGymAPI.Application.DTO.RutinaEjercicios
{
    public class RutinaEjercicioCreateRequestDto
    {
        public Guid RutinaId { get; set; }
        public Guid EjercicioId { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public float? PesoObjetivo { get; set; }
        public int? DescansoSeg { get; set; }
        public int Orden { get; set; }
    }
}