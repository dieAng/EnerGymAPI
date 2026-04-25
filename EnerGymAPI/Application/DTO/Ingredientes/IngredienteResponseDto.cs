using System;

namespace EnerGymAPI.Application.DTO.Ingredientes
{
    public class IngredienteResponseDto
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public float? Calorias { get; set; }
        public float? Proteinas { get; set; }
        public float? Carbohidratos { get; set; }
        public float? Grasas { get; set; }
    }
}