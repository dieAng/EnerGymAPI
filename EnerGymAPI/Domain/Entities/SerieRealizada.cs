using System;

 namespace EnerGymAPI.Domain.Entities
{
    public class SerieRealizada
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SesionEntrenamientoId { get; set; }
        public Guid EjercicioId { get; set; }
        public int Repeticiones { get; set; }
        public float Peso { get; set; }

         // Relaciones
        public SesionEntrenamiento? SesionEntrenamiento { get; set; }
        public Ejercicio? Ejercicio { get; set; }
    }
}