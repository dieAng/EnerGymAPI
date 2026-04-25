using System;
using System.Collections.Generic;

 namespace EnerGymAPI.Domain.Entities
{
    public class Ejercicio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Nombre { get; set; }
        public string? GrupoMuscular { get; set; }
        public string? Equipo { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenUrl { get; set; }
        public string? VideoUrl { get; set; }

         // Relaciones
        public ICollection<RutinaEjercicio> RutinasEjercicios { get; set; } = new List<RutinaEjercicio>();
    }
}