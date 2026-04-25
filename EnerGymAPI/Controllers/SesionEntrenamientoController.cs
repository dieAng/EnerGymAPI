using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Sesiones;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SesionEntrenamientoController : ControllerBase
    {
        private readonly ISesionEntrenamientoService _sesionService;

        public SesionEntrenamientoController(ISesionEntrenamientoService sesionService)
        {
            _sesionService = sesionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SesionEntrenamientoResponseDto>>> GetSesiones()
        {
            var sesiones = await _sesionService.GetSesionesAsync();
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SesionEntrenamientoResponseDto>> GetSesion(Guid id)
        {
            var sesion = await _sesionService.GetSesionByIdAsync(id);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }

        [HttpPost]
        public async Task<ActionResult<SesionEntrenamientoResponseDto>> CreateSesion(SesionEntrenamientoCreateRequestDto request)
        {
            var nuevaSesion = await _sesionService.CreateSesionAsync(request);
            return CreatedAtAction(nameof(GetSesion), new { id = nuevaSesion.Id }, nuevaSesion);
        }
    }
}