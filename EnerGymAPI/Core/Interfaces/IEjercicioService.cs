using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Ejercicios;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IEjercicioService
    {
        Task<IEnumerable<EjercicioResponseDto>> GetEjerciciosAsync();
        Task<EjercicioResponseDto> GetEjercicioByIdAsync(Guid id);
        Task<EjercicioResponseDto> CreateEjercicioAsync(EjercicioCreateRequestDto request);
    }
}