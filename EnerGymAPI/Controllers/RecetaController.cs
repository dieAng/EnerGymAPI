using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Recetas;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly IRecetaService _recetaService;

        public RecetaController(IRecetaService recetaService)
        {
            _recetaService = recetaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecetaResponseDto>>> GetRecetas()
        {
            var recetas = await _recetaService.GetRecetasAsync();
            return Ok(recetas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecetaResponseDto>> GetReceta(Guid id)
        {
            var receta = await _recetaService.GetRecetaByIdAsync(id);
            if (receta == null)
            {
                return NotFound();
            }
            return Ok(receta);
        }

        [HttpPost]
        public async Task<ActionResult<RecetaResponseDto>> CreateReceta(RecetaCreateRequestDto request)
        {
            var nuevaReceta = await _recetaService.CreateRecetaAsync(request);
            return CreatedAtAction(nameof(GetReceta), new { id = nuevaReceta.Id }, nuevaReceta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(Guid id)
        {
            var resultado = await _recetaService.DeleteRecetaAsync(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}