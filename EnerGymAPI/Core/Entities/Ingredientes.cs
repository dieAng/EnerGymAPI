namespace EnerGymAPI.Entities;

public class Ingrediente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid RecetaId { get; set; }
    public string Nombre { get; set; }
    public string Cantidad { get; set; }

    public Receta Receta { get; set; }
}