namespace EnerGymAPI.Application.DTO.Usuarios;

public class UsuarioReadDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public int? Edad { get; set; }
    public float? Peso { get; set; }
    public float? Altura { get; set; }
    public string Objetivo { get; set; }
    public string FotoUrl { get; set; }
    public string Rol { get; set; }
}