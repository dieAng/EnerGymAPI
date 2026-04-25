using System;

namespace EnerGymAPI.Application.DTO.Rutinas
{
    public class RutinaResponseDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Nivel { get; set; }
        public string? Objetivo { get; set; }
        public bool EsPredisenada { get; set; }
    }
}