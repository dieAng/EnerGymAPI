using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.RutinaEjercicios;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class RutinaEjercicioService : IRutinaEjercicioService
    {
        private readonly EnerGymDbContext _context;

        public RutinaEjercicioService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RutinaEjercicioResponseDto>> GetEjerciciosPorRutinaAsync(Guid rutinaId)
        {
            return await _context.RutinaEjercicios
                .Where(re => re.RutinaId == rutinaId)
                .OrderBy(re => re.Orden)
                .Select(re => new RutinaEjercicioResponseDto
                {
                    RutinaId = re.RutinaId,
                    EjercicioId = re.EjercicioId,
                    Series = re.Series,
                    Repeticiones = re.Repeticiones,
                    PesoObjetivo = re.PesoObjetivo,
                    DescansoSeg = re.DescansoSeg,
                    Orden = re.Orden
                })
                .ToListAsync();
        }

        public async Task<RutinaEjercicioResponseDto> AddEjercicioARutinaAsync(RutinaEjercicioCreateRequestDto request)
        {
            var rutinaEjercicio = new RutinaEjercicio
            {
                RutinaId = request.RutinaId,
                EjercicioId = request.EjercicioId,
                Series = request.Series,
                Repeticiones = request.Repeticiones,
                PesoObjetivo = request.PesoObjetivo,
                DescansoSeg = request.DescansoSeg,
                Orden = request.Orden
            };

            _context.RutinaEjercicios.Add(rutinaEjercicio);
            await _context.SaveChangesAsync();

            return new RutinaEjercicioResponseDto
            {
                RutinaId = rutinaEjercicio.RutinaId,
                EjercicioId = rutinaEjercicio.EjercicioId,
                Series = rutinaEjercicio.Series,
                Repeticiones = rutinaEjercicio.Repeticiones,
                PesoObjetivo = rutinaEjercicio.PesoObjetivo,
                DescansoSeg = rutinaEjercicio.DescansoSeg,
                Orden = rutinaEjercicio.Orden
            };
        }

        public async Task<bool> RemoveEjercicioDeRutinaAsync(Guid rutinaId, Guid ejercicioId)
        {
            var rutinaEjercicio = await _context.RutinaEjercicios
                .FirstOrDefaultAsync(re => re.RutinaId == rutinaId && re.EjercicioId == ejercicioId);
                
            if (rutinaEjercicio == null) return false;

            _context.RutinaEjercicios.Remove(rutinaEjercicio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}