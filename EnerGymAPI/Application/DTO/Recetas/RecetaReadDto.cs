using EnerGymAPI.Application.DTO.Ingredientes;

namespace EnerGymAPI.Application.DTO.Recetas;

public class RecetaReadDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int? TiempoPreparacion { get; set; }
    public string Alergenos { get; set; }
    public string ImagenUrl { get; set; }
    public string Descripcion { get; set; }
    public bool EsPredisenada { get; set; }

    public List<IngredienteReadDto> Ingredientes { get; set; }
}