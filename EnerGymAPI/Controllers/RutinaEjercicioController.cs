using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.RutinaEjercicios;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaEjercicioController : ControllerBase
    {
        private readonly IRutinaEjercicioService _rutinaEjercicioService;

        public RutinaEjercicioController(IRutinaEjercicioService rutinaEjercicioService)
        {
            _rutinaEjercicioService = rutinaEjercicioService;
        }

        [HttpGet("rutina/{rutinaId}")]
        public async Task<ActionResult<IEnumerable<RutinaEjercicioResponseDto>>> GetEjerciciosPorRutina(Guid rutinaId)
        {
            var ejercicios = await _rutinaEjercicioService.GetEjerciciosPorRutinaAsync(rutinaId);
            return Ok(ejercicios);
        }

        [HttpPost]
        public async Task<ActionResult<RutinaEjercicioResponseDto>> AddEjercicioARutina(RutinaEjercicioCreateRequestDto request)
        {
            var nuevoEjercicio = await _rutinaEjercicioService.AddEjercicioARutinaAsync(request);
            return Ok(nuevoEjercicio);
        }

        [HttpDelete("{rutinaId}/{ejercicioId}")]
        public async Task<IActionResult> RemoveEjercicioDeRutina(Guid rutinaId, Guid ejercicioId)
        {
            var resultado = await _rutinaEjercicioService.RemoveEjercicioDeRutinaAsync(rutinaId, ejercicioId);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}