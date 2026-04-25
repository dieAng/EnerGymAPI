using System;

 namespace EnerGymAPI.Domain.Entities
{
    public class LikePost
    {
        public Guid PostId { get; set; }
        public Guid UsuarioId { get; set; }

         // Relaciones
        public Post? Post { get; set; }
        public Usuario? Usuario { get; set; }
    }
}