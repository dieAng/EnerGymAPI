using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Comentarios;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly EnerGymDbContext _context;

        public ComentarioService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComentarioResponseDto>> GetComentariosPorPostAsync(Guid postId)
        {
            return await _context.Comentarios
                .Where(c => c.PostId == postId)
                .Select(c => new ComentarioResponseDto
                {
                    Id = c.Id,
                    PostId = c.PostId,
                    UsuarioId = c.UsuarioId,
                    Contenido = c.Contenido,
                    Fecha = c.Fecha
                })
                .ToListAsync();
        }

        public async Task<ComentarioResponseDto> CreateComentarioAsync(ComentarioCreateRequestDto request)
        {
            var comentario = new Comentario
            {
                PostId = request.PostId,
                UsuarioId = request.UsuarioId,
                Contenido = request.Contenido,
                Fecha = request.Fecha == 0 ? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() : request.Fecha
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return new ComentarioResponseDto
            {
                Id = comentario.Id,
                PostId = comentario.PostId,
                UsuarioId = comentario.UsuarioId,
                Contenido = comentario.Contenido,
                Fecha = comentario.Fecha
            };
        }

        public async Task<bool> DeleteComentarioAsync(Guid id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return false;

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}