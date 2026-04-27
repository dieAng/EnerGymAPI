using System;

namespace EnerGymAPI.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public required string Token { get; set; }
        
        public required Guid UsuarioId { get; set; }
        
        public DateTime ExpiryDate { get; set; }
        
        public bool IsRevoked { get; set; } = false;
        
        public bool IsUsed { get; set; } = false;

        // Propiedad de navegación
        public Usuario? Usuario { get; set; }
    }
}