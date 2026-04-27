using System;
using System.Collections.Generic;

namespace EnerGymAPI.Domain.Entities
{
    public class SesionEntrenamiento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid UsuarioId { get; set; }
        public Guid? RutinaId { get; set; }
        
        // Android is using Long for `fecha`, usually translating to Unix Timestamp (milliseconds/seconds)
        // In C# we'll map this to long for accurate binding, or keep DateTime if the mapper handles it.
        // Assuming Unix Timestamp (long) since the Android client uses `val fecha: Long`
        public long Fecha { get; set; }
        
        public int? DuracionSegundos { get; set; } = 0;
        public int? EnergiaGeneradaWh { get; set; } = 0;
        public int? CaloriasQuemadas { get; set; } = 0;

        // Navigation properties (if needed by EF Core)
        public Usuario? Usuario { get; set; }
        public Rutina? Rutina { get; set; }
        public ICollection<SerieRealizada> SeriesRealizadas { get; set; } = new List<SerieRealizada>();
    }
}