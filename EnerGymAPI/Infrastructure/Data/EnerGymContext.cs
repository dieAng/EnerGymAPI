using EnerGymAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Infrastructure.Data;
public class EnerGymContext : DbContext
{
    public EnerGymContext(DbContextOptions<EnerGymContext> options) : base(options) {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Receta> Recetas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Rutina> Rutinas { get; set; }
    public DbSet<Ejercicio> Ejercicios { get; set; }
    public DbSet<RutinaEjercicio> RutinaEjercicios { get; set; }
    public DbSet<SesionEntrenamiento> Sesiones { get; set; }
    public DbSet<SerieRealizada> SeriesRealizadas { get; set; }
    public DbSet<Mensaje> Mensajes { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<LikePost> Likes { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Clave compuesta RutinaEjercicio
        modelBuilder.Entity<RutinaEjercicio>()
            .HasKey(re => new { re.RutinaId, re.EjercicioId });

        // Clave compuesta LikePost
        modelBuilder.Entity<LikePost>()
            .HasKey(lp => new { lp.PostId, lp.UsuarioId });

        // Relaciones Mensaje
        modelBuilder.Entity<Mensaje>()
            .HasOne(m => m.Emisor)
            .WithMany(u => u.MensajesEnviados)
            .HasForeignKey(m => m.EmisorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Mensaje>()
            .HasOne(m => m.Receptor)
            .WithMany(u => u.MensajesRecibidos)
            .HasForeignKey(m => m.ReceptorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}