using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Comentarios;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet("post/{postId}")]
        public async Task<ActionResult<IEnumerable<ComentarioResponseDto>>> GetComentariosPorPost(Guid postId)
        {
            var comentarios = await _comentarioService.GetComentariosPorPostAsync(postId);
            return Ok(comentarios);
        }

        [HttpPost]
        public async Task<ActionResult<ComentarioResponseDto>> CreateComentario(ComentarioCreateRequestDto request)
        {
            var nuevoComentario = await _comentarioService.CreateComentarioAsync(request);
            return Ok(nuevoComentario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(Guid id)
        {
            var resultado = await _comentarioService.DeleteComentarioAsync(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}