using EnerGymAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Infrastructure.Data
{
    public class EnerGymDbContext : DbContext
    {
        public EnerGymDbContext(DbContextOptions<EnerGymDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<SesionEntrenamiento> SesionesEntrenamiento { get; set; }
        public DbSet<RutinaEjercicio> RutinaEjercicios { get; set; }
        public DbSet<LikePost> LikePosts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<SerieRealizada> SeriesRealizadas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Llave primaria compuesta para LikePost
            modelBuilder.Entity<LikePost>()
                .HasKey(lp => new { lp.PostId, lp.UsuarioId });

            // Relación LikePost -> Usuario
            modelBuilder.Entity<LikePost>()
                .HasOne(lp => lp.Usuario)
                .WithMany(u => u.Likes)
                .HasForeignKey(lp => lp.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación LikePost -> Post
            modelBuilder.Entity<LikePost>()
                .HasOne(lp => lp.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(lp => lp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Llave primaria compuesta para RutinaEjercicio
            modelBuilder.Entity<RutinaEjercicio>()
                .HasKey(re => new { re.RutinaId, re.EjercicioId });
            
            // Relación RutinaEjercicio -> Rutina
            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.Rutina)
                .WithMany(r => r.RutinasEjercicios)
                .HasForeignKey(re => re.RutinaId);

            // Relación RutinaEjercicio -> Ejercicio
            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.Ejercicio)
                .WithMany(e => e.RutinasEjercicios)
                .HasForeignKey(re => re.EjercicioId);

            // Relaciones para Mensaje
            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Emisor)
                .WithMany(u => u.MensajesEnviados)
                .HasForeignKey(m => m.EmisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Receptor)
                .WithMany(u => u.MensajesRecibidos)
                .HasForeignKey(m => m.ReceptorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
