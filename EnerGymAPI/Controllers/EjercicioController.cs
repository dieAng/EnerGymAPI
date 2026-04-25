using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Ejercicios;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private readonly IEjercicioService _ejercicioService;

        public EjercicioController(IEjercicioService ejercicioService)
        {
            _ejercicioService = ejercicioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EjercicioResponseDto>>> GetEjercicios()
        {
            var ejercicios = await _ejercicioService.GetEjerciciosAsync();
            return Ok(ejercicios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EjercicioResponseDto>> GetEjercicio(Guid id)
        {
            var ejercicio = await _ejercicioService.GetEjercicioByIdAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            return Ok(ejercicio);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<EjercicioResponseDto>> CreateEjercicio(EjercicioCreateRequestDto request)
        {
            var nuevoEjercicio = await _ejercicioService.CreateEjercicioAsync(request);
            return CreatedAtAction(nameof(GetEjercicio), new { id = nuevoEjercicio.Id }, nuevoEjercicio);
        }
    }
}