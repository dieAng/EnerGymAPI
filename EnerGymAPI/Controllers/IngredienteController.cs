using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Ingredientes;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredienteResponseDto>>> GetIngredientes()
        {
            var ingredientes = await _ingredienteService.GetIngredientesAsync();
            return Ok(ingredientes);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<IngredienteResponseDto>> CreateIngrediente(IngredienteCreateRequestDto request)
        {
            var nuevoIngrediente = await _ingredienteService.CreateIngredienteAsync(request);
            return Ok(nuevoIngrediente);
        }
    }
}