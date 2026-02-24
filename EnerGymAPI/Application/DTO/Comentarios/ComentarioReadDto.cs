namespace EnerGymAPI.Application.DTO.Comentarios;

public class ComentarioReadDto
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; }
}