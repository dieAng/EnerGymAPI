namespace EnerGymAPI.Application.DTO.Recetas;

public class RecetaUpdateDto
{
    public string Nombre { get; set; }
    public int? TiempoPreparacion { get; set; }
    public string Alergenos { get; set; }
    public string ImagenUrl { get; set; }
    public string Descripcion { get; set; }
}