using System;

 namespace EnerGymAPI.Domain.Entities
{
    public class Receta
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public int? TiempoPreparacion { get; set; }
        public string? Alergenos { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Descripcion { get; set; }
        public bool EsPredisenada { get; set; } = false;

         // Relaciones
        public Usuario? Usuario { get; set; }
    }
}