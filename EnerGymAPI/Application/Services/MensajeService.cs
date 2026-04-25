using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Mensajes;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class MensajeService : IMensajeService
    {
        private readonly EnerGymDbContext _context;

        public MensajeService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MensajeResponseDto>> GetMensajesAsync(Guid usuarioId1, Guid usuarioId2)
        {
            return await _context.Mensajes
                .Where(m => (m.EmisorId == usuarioId1 && m.ReceptorId == usuarioId2) ||
                            (m.EmisorId == usuarioId2 && m.ReceptorId == usuarioId1))
                .OrderBy(m => m.Fecha)
                .Select(m => new MensajeResponseDto
                {
                    Id = m.Id,
                    EmisorId = m.EmisorId,
                    ReceptorId = m.ReceptorId,
                    Contenido = m.Contenido,
                    Fecha = m.Fecha
                })
                .ToListAsync();
        }

        public async Task<MensajeResponseDto> CreateMensajeAsync(MensajeCreateRequestDto request)
        {
            var mensaje = new Mensaje
            {
                EmisorId = request.EmisorId,
                ReceptorId = request.ReceptorId,
                Contenido = request.Contenido,
                Fecha = request.Fecha == 0 ? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() : request.Fecha
            };

            _context.Mensajes.Add(mensaje);
            await _context.SaveChangesAsync();

            return new MensajeResponseDto
            {
                Id = mensaje.Id,
                EmisorId = mensaje.EmisorId,
                ReceptorId = mensaje.ReceptorId,
                Contenido = mensaje.Contenido,
                Fecha = mensaje.Fecha
            };
        }
    }
}