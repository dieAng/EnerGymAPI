using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Sesiones;

namespace EnerGymAPI.Core.Interfaces
{
    public interface ISesionEntrenamientoService
    {
        Task<IEnumerable<SesionEntrenamientoResponseDto>> GetSesionesAsync();
        Task<SesionEntrenamientoResponseDto> GetSesionByIdAsync(Guid id);
        Task<SesionEntrenamientoResponseDto> CreateSesionAsync(SesionEntrenamientoCreateRequestDto request);
    }
}