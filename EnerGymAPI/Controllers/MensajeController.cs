using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Mensajes;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeController : ControllerBase
    {
        private readonly IMensajeService _mensajeService;

        public MensajeController(IMensajeService mensajeService)
        {
            _mensajeService = mensajeService;
        }

        [HttpGet("{usuarioId1}/{usuarioId2}")]
        public async Task<ActionResult<IEnumerable<MensajeResponseDto>>> GetMensajes(Guid usuarioId1, Guid usuarioId2)
        {
            var mensajes = await _mensajeService.GetMensajesAsync(usuarioId1, usuarioId2);
            return Ok(mensajes);
        }

        [HttpPost]
        public async Task<ActionResult<MensajeResponseDto>> CreateMensaje(MensajeCreateRequestDto request)
        {
            var nuevoMensaje = await _mensajeService.CreateMensajeAsync(request);
            return Ok(nuevoMensaje);
        }
    }
}