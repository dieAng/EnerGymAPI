namespace EnerGymAPI.Entities;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UsuarioId { get; set; }
    public string Contenido { get; set; }
    public string ImagenUrl { get; set; }
    public DateTime Fecha { get; set; }

    public Usuario Usuario { get; set; }
    public ICollection<Comentario> Comentarios { get; set; }
    public ICollection<LikePost> Likes { get; set; }
}