using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Rutinas;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IRutinaService
    {
        Task<IEnumerable<RutinaResponseDto>> GetRutinasAsync();
        Task<RutinaResponseDto> GetRutinaByIdAsync(Guid id);
        Task<RutinaResponseDto> CreateRutinaAsync(RutinaCreateRequestDto request);
        Task<bool> DeleteRutinaAsync(Guid id);
    }
}