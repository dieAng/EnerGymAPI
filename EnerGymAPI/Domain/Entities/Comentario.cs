using System;

 namespace EnerGymAPI.Domain.Entities
{
    public class Comentario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PostId { get; set; }
        public Guid UsuarioId { get; set; }
        public required string Contenido { get; set; }
        public long Fecha { get; set; }

         // Relaciones
        public Post? Post { get; set; }
        public Usuario? Usuario { get; set; }
    }
}