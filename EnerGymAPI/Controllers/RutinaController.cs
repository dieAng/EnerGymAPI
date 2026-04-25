using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Rutinas;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        private readonly IRutinaService _rutinaService;

        public RutinaController(IRutinaService rutinaService)
        {
            _rutinaService = rutinaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutinaResponseDto>>> GetRutinas()
        {
            var rutinas = await _rutinaService.GetRutinasAsync();
            return Ok(rutinas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RutinaResponseDto>> GetRutina(Guid id)
        {
            var rutina = await _rutinaService.GetRutinaByIdAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }
            return Ok(rutina);
        }

        [HttpPost]
        public async Task<ActionResult<RutinaResponseDto>> CreateRutina(RutinaCreateRequestDto request)
        {
            var nuevaRutina = await _rutinaService.CreateRutinaAsync(request);
            return CreatedAtAction(nameof(GetRutina), new { id = nuevaRutina.Id }, nuevaRutina);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutina(Guid id)
        {
            var resultado = await _rutinaService.DeleteRutinaAsync(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}