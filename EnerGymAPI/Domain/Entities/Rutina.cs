using System;
using System.Collections.Generic;

namespace EnerGymAPI.Domain.Entities
{
    public class Rutina
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Nivel { get; set; }
        public string? Objetivo { get; set; }
        public bool EsPredisenada { get; set; } = false;

         // Relaciones
        public Usuario? Usuario { get; set; }
        public ICollection<RutinaEjercicio> RutinasEjercicios { get; set; } = new List<RutinaEjercicio>();
        public ICollection<SesionEntrenamiento> Sesiones { get; set; } = new List<SesionEntrenamiento>();
    }
}