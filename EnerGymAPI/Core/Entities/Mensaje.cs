namespace EnerGymAPI.Entities;

public class Mensaje
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EmisorId { get; set; }
    public Guid ReceptorId { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; }

    public Usuario Emisor { get; set; }
    public Usuario Receptor { get; set; }
}