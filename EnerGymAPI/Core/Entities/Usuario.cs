namespace EnerGymAPI.Entities;

public class Usuario
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int? Edad { get; set; }
    public float? Peso { get; set; }
    public float? Altura { get; set; }
    public string Objetivo { get; set; }
    public string FotoUrl { get; set; }
    public string Rol { get; set; } = "usuario";

    public ICollection<Receta> Recetas { get; set; }
    public ICollection<Rutina> Rutinas { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Mensaje> MensajesEnviados { get; set; }
    public ICollection<Mensaje> MensajesRecibidos { get; set; }
}