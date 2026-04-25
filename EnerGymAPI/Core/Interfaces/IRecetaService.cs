using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Recetas;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IRecetaService
    {
        Task<IEnumerable<RecetaResponseDto>> GetRecetasAsync();
        Task<RecetaResponseDto> GetRecetaByIdAsync(Guid id);
        Task<RecetaResponseDto> CreateRecetaAsync(RecetaCreateRequestDto request);
        Task<bool> DeleteRecetaAsync(Guid id);
    }
}