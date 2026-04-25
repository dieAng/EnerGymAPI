using System;

namespace EnerGymAPI.Application.DTO.Recetas
{
    public class RecetaResponseDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public int? TiempoPreparacion { get; set; }
        public string? Alergenos { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Descripcion { get; set; }
        public bool EsPredisenada { get; set; }
    }
}