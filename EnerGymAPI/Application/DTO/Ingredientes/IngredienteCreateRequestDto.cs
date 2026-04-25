namespace EnerGymAPI.Application.DTO.Ingredientes
{
    public class IngredienteCreateRequestDto
    {
        public required string Nombre { get; set; }
        public float? Calorias { get; set; }
        public float? Proteinas { get; set; }
        public float? Carbohidratos { get; set; }
        public float? Grasas { get; set; }
    }
}