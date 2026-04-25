using System;

 namespace EnerGymAPI.Domain.Entities
{
    public class Ingrediente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Nombre { get; set; }
        public float? Calorias { get; set; }
        public float? Proteinas { get; set; }
        public float? Carbohidratos { get; set; }
        public float? Grasas { get; set; }
    }
}