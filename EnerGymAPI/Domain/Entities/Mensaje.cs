using System;

 namespace EnerGymAPI.Domain.Entities
{
    public class Mensaje
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid EmisorId { get; set; }
        public Guid ReceptorId { get; set; }
        public required string Contenido { get; set; }
        public long Fecha { get; set; } // O DateTime

         // Relaciones
        public Usuario? Emisor { get; set; }
        public Usuario? Receptor { get; set; }
    }
}