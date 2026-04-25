using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Sesiones;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class SesionEntrenamientoService : ISesionEntrenamientoService
    {
        private readonly EnerGymDbContext _context;

        public SesionEntrenamientoService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SesionEntrenamientoResponseDto>> GetSesionesAsync()
        {
            return await _context.SesionesEntrenamiento
                .Select(s => new SesionEntrenamientoResponseDto
                {
                    Id = s.Id,
                    UsuarioId = s.UsuarioId,
                    RutinaId = s.RutinaId,
                    Fecha = s.Fecha,
                    DuracionSegundos = s.DuracionSegundos,
                    EnergiaGeneradaWh = s.EnergiaGeneradaWh,
                    CaloriasQuemadas = s.CaloriasQuemadas
                })
                .ToListAsync();
        }

        public async Task<SesionEntrenamientoResponseDto> GetSesionByIdAsync(Guid id)
        {
            var sesion = await _context.SesionesEntrenamiento.FindAsync(id);
            if (sesion == null) return null;

            return new SesionEntrenamientoResponseDto
            {
                Id = sesion.Id,
                UsuarioId = sesion.UsuarioId,
                RutinaId = sesion.RutinaId,
                Fecha = sesion.Fecha,
                DuracionSegundos = sesion.DuracionSegundos,
                EnergiaGeneradaWh = sesion.EnergiaGeneradaWh,
                CaloriasQuemadas = sesion.CaloriasQuemadas
            };
        }

        public async Task<SesionEntrenamientoResponseDto> CreateSesionAsync(SesionEntrenamientoCreateRequestDto request)
        {
            var sesion = new SesionEntrenamiento
            {
                UsuarioId = request.UsuarioId,
                RutinaId = request.RutinaId,
                Fecha = request.Fecha == 0 ? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() : request.Fecha,
                DuracionSegundos = request.DuracionSegundos,
                EnergiaGeneradaWh = request.EnergiaGeneradaWh,
                CaloriasQuemadas = request.CaloriasQuemadas
            };

            _context.SesionesEntrenamiento.Add(sesion);
            await _context.SaveChangesAsync();

            return new SesionEntrenamientoResponseDto
            {
                Id = sesion.Id,
                UsuarioId = sesion.UsuarioId,
                RutinaId = sesion.RutinaId,
                Fecha = sesion.Fecha,
                DuracionSegundos = sesion.DuracionSegundos,
                EnergiaGeneradaWh = sesion.EnergiaGeneradaWh,
                CaloriasQuemadas = sesion.CaloriasQuemadas
            };
        }
    }
}