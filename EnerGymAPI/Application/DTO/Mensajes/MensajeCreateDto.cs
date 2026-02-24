namespace EnerGymAPI.Application.DTO.Mensajes;

public class MensajeCreateDto
{
    public Guid ReceptorId { get; set; }
    public string Contenido { get; set; }
}