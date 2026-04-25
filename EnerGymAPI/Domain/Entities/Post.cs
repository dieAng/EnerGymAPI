using System;
using System.Collections.Generic;

 namespace EnerGymAPI.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string? Contenido { get; set; }
        public string? ImagenUrl { get; set; }
        public double EnergiaGenerada { get; set; } = 0.0;
        public long Fecha { get; set; } // O DateTime, dependiendo de cómo manejes las fechas
         
        // Relaciones
        public Usuario? Usuario { get; set; }
        public ICollection<LikePost> Likes { get; set; } = new List<LikePost>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}