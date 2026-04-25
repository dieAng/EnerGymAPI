using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Ingredientes;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IIngredienteService
    {
        Task<IEnumerable<IngredienteResponseDto>> GetIngredientesAsync();
        Task<IngredienteResponseDto> CreateIngredienteAsync(IngredienteCreateRequestDto request);
    }
}