namespace EnerGymAPI.Application.DTO.Mensajes;

public class MensajeReadDto
{
    public Guid Id { get; set; }
    public Guid EmisorId { get; set; }
    public Guid ReceptorId { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; }
}