using System;
using System.Collections.Generic;

 namespace EnerGymAPI.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public int? Edad { get; set; }
        public float? Peso { get; set; }
        public float? Altura { get; set; }
        public string? Objetivo { get; set; }
        public string? FotoUrl { get; set; }
        public string Rol { get; set; } = "usuario";
         
        // Relaciones
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Rutina> Rutinas { get; set; } = new List<Rutina>();
        public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
        public ICollection<LikePost> Likes { get; set; } = new List<LikePost>();
        public ICollection<SesionEntrenamiento> Sesiones { get; set; } = new List<SesionEntrenamiento>();
        public ICollection<Mensaje> MensajesEnviados { get; set; } = new List<Mensaje>();
        public ICollection<Mensaje> MensajesRecibidos { get; set; } = new List<Mensaje>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    } 
}