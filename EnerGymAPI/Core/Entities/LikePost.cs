namespace EnerGymAPI.Entities;

public class LikePost
{
    public Guid PostId { get; set; }
    public Guid UsuarioId { get; set; }

    public Post Post { get; set; }
    public Usuario Usuario { get; set; }
}