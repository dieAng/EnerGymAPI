using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.RutinaEjercicios;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IRutinaEjercicioService
    {
        Task<IEnumerable<RutinaEjercicioResponseDto>> GetEjerciciosPorRutinaAsync(Guid rutinaId);
        Task<RutinaEjercicioResponseDto> AddEjercicioARutinaAsync(RutinaEjercicioCreateRequestDto request);
        Task<bool> RemoveEjercicioDeRutinaAsync(Guid rutinaId, Guid ejercicioId);
    }
}