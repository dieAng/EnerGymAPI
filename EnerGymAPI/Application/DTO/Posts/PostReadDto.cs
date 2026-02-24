using EnerGymAPI.Application.DTO.Comentarios;

namespace EnerGymAPI.Application.DTO.Posts;

public class PostReadDto
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string Contenido { get; set; }
    public string ImagenUrl { get; set; }
    public DateTime Fecha { get; set; }

    public int Likes { get; set; }
    public List<ComentarioReadDto> Comentarios { get; set; }
}