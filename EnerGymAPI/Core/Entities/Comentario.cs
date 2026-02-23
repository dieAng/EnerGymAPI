namespace EnerGymAPI.Entities;

public class Comentario
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PostId { get; set; }
    public Guid UsuarioId { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; }

    public Post Post { get; set; }
    public Usuario Usuario { get; set; }
}